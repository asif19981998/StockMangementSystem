//Core React Import
import React, { useEffect,useState } from "react";
import { connect } from "react-redux";
import { useToasts } from "react-toast-notifications";
import { Redirect } from 'react-router-dom';
import {Card,CardHeader,CardTitle,CardBody,FormGroup,Label} from "reactstrap";

//Third Party


//App File
import Product from "../utils/product";
import useForm from "../utils/useForm";
import * as actions from "../../../../redux/actions/core/product/product";




 const initialFieldValues = new Product();

function ProductCreate({ ...props }) {
  const [currentId,setCurrentId]=useState(0);
  const [showList,setShowList]=useState(false);
  const { addToast } = useToasts();
  
 const validate = (fieldValues = values) => {
    let temp = { ...errors }
    if ('name' in fieldValues)
        temp.name = fieldValues.name ? "" : "This field is required."
  
    setErrors({
        ...temp
    })

    if (fieldValues == values)
        return Object.values(temp).every(x => x == "")
}
  
 const { values, setValues, errors, setErrors, handleInputChange, resetForm } =
     useForm(initialFieldValues, validate, setCurrentId);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validate()) {
      const onSuccess = () => {
        if(currentId != 0){
          localStorage.removeItem("currentId")
          setShowList(true)
         }
        resetForm();
        addToast("Submitted successfully", { appearance: "success" });
      };
      if (currentId == 0 || currentId== null) {
        console.log(values)
        props.createproduct(values, onSuccess);
      } else {
        console.log(currentId)
        console.log("call update in create");
        props.updateproduct(currentId, values, onSuccess);
      }
    }
  };
  
  useEffect(() => {
    if (currentId != 0) {
      setValues({
        ...props.productList.find((x) => x.id == currentId),
      });
      setErrors({});
      return ()=>{
        setCurrentId(0)
        localStorage.removeItem("currentId")
      }
    }
    setCurrentId(localStorage.getItem("currentId"))
  }, [currentId]);
  if(showList) {
    return <Redirect to="/productList"/>
  }
  return (
    
    <Card>
      <CardHeader>
        <CardTitle>Create Product</CardTitle>
      </CardHeader>
      <CardBody>
        <form onSubmit={handleSubmit}>
          <Label>Name</Label>
          <FormGroup>
          <input
          id="name"
          placeholder="Name"
          name="name"
          type="text"
          value={values.name}
          onChange={handleInputChange}
          className="form-control"
        />
         {errors.name && <div style={{color:"red"}}>{errors.name}</div>}
            </FormGroup>
        <FormGroup>
          <Label>Code</Label>
        <input
          id="code"
          placeholder="Code"
          name="code"
          type="text"
          value={values.code}
          onChange={handleInputChange}
          className="form-control"
        />
        </FormGroup>
       
        
        {currentId  == 0 || currentId == null ?(
          <button
          style={{ marginTop: "3px" }}
          type="submit"
          className="btn btn-primary"
        >
          Submit
        </button>
        ):
        <button
          style={{ marginTop: "3px" }}
          type="submit"
          className="btn btn-primary"
        >
          Update
        </button>}
        
      </form>
    
  
      </CardBody>
    </Card>
   
  
  );
}
const mapStateToProps = (state) => ({
  productList: state.product.list,
});

const mapActionToProps = {
  createproduct: actions.create,
  updateproduct: actions.update,
};

export default connect(mapStateToProps, mapActionToProps)(ProductCreate);
