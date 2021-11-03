//Core React Import
import React, { useEffect,useState } from "react";
import { connect } from "react-redux";
import { useToasts } from "react-toast-notifications";
import { Redirect } from 'react-router-dom';


//Third Party
import {Card,CardHeader,CardTitle,CardBody,FormGroup,Label,Input} from "reactstrap";

//App File
import Stock from "../utils/stock";
import useForm from "../../../common/file/useForm";
import * as actions from "../../../../redux/actions/core/stock/stock";
import * as productActions from "../../../../redux/actions/core/product/product";
import {getDistrict,getDivison,getUpazila,getUpazilaByDistrict} from "../../../services/configDataServices"


const initialFieldValues = new Stock();


function StockCreate({ ...props }) {
  const [currentId,setCurrentId]=useState(0);
  const [showList,setShowList]=useState(false);
  const { addToast } = useToasts();
  const[districtList,setDistrictList]=useState([]);
  const[upazilaList,setUpazilaList]=useState([])
  
  
  const validate = () => {
    return true;
  };

  
  
  const { values, setValues, errors, setErrors, handleInputChange, resetForm } =
    useForm(initialFieldValues, validate);

    const getUpazilaBaseOnDistrict=(e)=>{
      
      getUpazilaByDistrict(e.target.value).then(response=>{
        console.log(response)
        setUpazilaList(response.data)
      })
     }

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
       

       var newData =  {...initialFieldValues,...values}
       console.log(newData)
        props.createStock(newData, onSuccess);
      } else {
       
        console.log("call update in create");
        props.updateStock(currentId, values, onSuccess);
      }
    }
  };
  
  useEffect(() => {
    props.getProduct();
    getDistrict().then(response=>{
      setDistrictList(response.data)
    })
   
    if (currentId != 0) {
      setValues({
        ...props.stockList.find((x) => x.id == currentId),
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
    return <Redirect to="/stockList"/>
  }
  return (
    <Card>
    <CardHeader>
      <CardTitle>Create Stock</CardTitle>
    </CardHeader>
    <CardBody>
      <form onSubmit={handleSubmit}>
      <FormGroup>
            <Label for="basicInput">Product </Label>
                    <Input 
                      type="select" 
                      name="productId" 
                      id="productId"
                      onChange={handleInputChange}
                      value={values.productId}
                      >
                      <option value={0}>---select---</option>
                      {props.productList.map(data=>(
                        
                          <option value={data.id}>{data.name}</option>
                       
                        
                      ))}
                    </Input>
        </FormGroup>
      <FormGroup>
            <Label for="basicInput">Quantity</Label>
            <Input
              id="quantity"
              placeholder="quantity"
              type="number"
              name="quantity"
              value={values.quantity}
              onChange={handleInputChange}
              className="form-control"
            />
          </FormGroup>
          <FormGroup>
            <Label for="basicInput">District </Label>
                    <Input 
                      type="select" 
                      name="districtId" 
                      id="branch"
                      onChange={getUpazilaBaseOnDistrict}
                      value={values.districtId}
                      
                      >
                      <option value={0}>---select---</option>
                      {districtList.map(data=>(
                       
                          <option  value={data.id}>
                         
                            {data.name}
                            
                          </option>
                        
                        
                      ))}
                    </Input>
        </FormGroup>
        <FormGroup>
            <Label for="basicInput">Upazila</Label>
                    <Input 
                      type="select" 
                      name="upazilaId" 
                      id="upazilaId"
                      onChange={handleInputChange}
                      value={values.upazilaId}
                      >
                      <option value={0}>---select---</option>
                      {upazilaList.map(data=>(
                        <option value={data.id}>{data.name}</option>
                      ))}
                    </Input>
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
  stockList: state.stock.list,
  productList:state.product.list
});

const mapActionToProps = {
  createStock: actions.create,
  updateStock: actions.update,
  getProduct:productActions.fetchAll
};

export default connect(mapStateToProps, mapActionToProps)(StockCreate);
