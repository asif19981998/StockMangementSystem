import React, { useState, useEffect} from "react";
import { connect } from "react-redux";
import * as actions from "../../../../redux/actions/core/stock/stock";
import {  withStyles} from "@material-ui/core";
import {Card,CardHeader,CardTitle,CardBody,FormGroup,Label,Input} from "reactstrap";
import { useToasts } from "react-toast-notifications";
import axios from "axios";
import EnhancedTable from "../../../common/component/table";
import {getDistrict,getDivison,getUpazila,getUpazilaByDistrict} from "../../../services/configDataServices"
import id from "date-fns/locale/id";
const styles = theme => ({
  root: {
    "& .MuiTableCell-head": {
      fontSize: "1.25rem"
    }
  },
  paper: {
    margin: theme.spacing(2),
    padding: theme.spacing(2)
  }
})

const StockList = ({ classes, ...props }) => {
  const [currentId, setCurrentId] = useState(0)
  const [page, setPage] = React.useState(0);
  const [stock,setStock]=useState([]);
  const[districtList,setDistrictList]=useState([]);
  const[upazilaList,setUpazilaList]=useState([])
  const[divisonList,setDivisonList]=useState([])
  const[searchName,setSearchName]=useState({districtId:"",divisonId:"",upazilaId:""})
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  
  const getAll=()=>{
    props.fetchAllStock()
  }

  const getDistrictData=(e)=>{
    var id = e.target.value
    if(id==0) getAll()
    else props.fetchByDistrictId(e.target.value)
   }
   const getDivisonData=(e)=>{
    var id = e.target.value
    if(id==0) getAll()
    else props.fetchByDivisonId(e.target.value)
   }
   const getUpazilaData=(e)=>{
    var id = e.target.value
    if(id==0) getAll()
    else props.fetchByUpazilaId(e.target.value)
   }
 
  
  useEffect(() => {
      getAll()
      getDistrict().then(response=>{
        setDistrictList(response.data)
      })
      getDivison().then(response=>{
        setDivisonList(response.data)
      })
      getUpazila().then(response=>{
        setUpazilaList(response.data)
      })
     setStock(props.stockList)
     console.log(props.stockList)
      
    },[stock] )


  const { addToast } = useToasts()

  const onDelete = id => {
    console.log(id);
    if (window.confirm('Are you sure to delete this record?'))
      props.deleteState(id, () => addToast("Deleted successfully", { appearance: 'info' }))
  }

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

 

  return (

    <Card>
      <CardHeader>
        <CardTitle>Stock Details </CardTitle>
        
        <FormGroup>
        <Label for="basicInput">District</Label>
        <Input 
                      type="select" 
                      name="district" 
                      id="district"
                      onChange={getDistrictData}
                      value={searchName.districtId}
                      
                      >
                      <option >---Select---</option>
                      <option value={0}>ALL</option>
                      {districtList.map(data=>(
                       
                          <option  value={data.id}>
                         
                            {data.name}
                            
                          </option>
                        
                        
                      ))}
       
        
        </Input>
          </FormGroup>
          <FormGroup>
        <Label for="basicInput">Divison</Label>
        <Input 
                      type="select" 
                      name="district" 
                      id="district"
                      onChange={getDivisonData}
                      value={searchName.divisonId}
                      
                      >
                      <option >---Select---</option>
                      <option value={0}>ALL</option>
                      {divisonList.map(data=>(
                       
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
                      name="district" 
                      id="district"
                      onChange={getUpazilaData}
                      value={searchName.upazilaId}
                      
                      >
                      <option >---Select---</option>
                      <option value={0}>ALL</option>
                      {upazilaList.map(data=>(
                       
                          <option  value={data.id}>
                         
                            {data.name}
                            
                          </option>
                        
                        
                      ))}
        </Input>
        </FormGroup>
        <a href="https://localhost:44388/api/stock/getReport" target="_blank" class="btn btn-success">Export Pdf</a>
        
     
      </CardHeader>
      <CardBody>
      <div elevation={3}>
     
     <table class="table">
 <thead>
   <tr>
     
     <th scope="col">Name</th>
     <th scope="col">Quantity</th>
     <th scope="col">Upazila</th>
     <th scope="col">District</th>
     <th scope="col">Divison</th>
   </tr>
 </thead>
 <tbody>
   
    {props.stockList.map(stock=>(
      <tr>
      <td>{stock.product?.name ?? "N/A"}</td>
      <td>{stock.quantity ?? "N/A"}</td>
      <td>{stock.upazila?.name ?? "N/A"}</td>
      <td>{stock.upazila?.district?.name ?? "N/A"}</td>
      <td>{stock.upazila?.district?.divison?.name ?? "N/A"}</td>
      </tr>
    ))}
   
  
 </tbody>
</table>
   </div>
      </CardBody>
    </Card>
   
  
  
  );
}

const mapStateToProps = state => ({
  stockList: state.stock.list
})

const mapActionToProps = {
  fetchAllStock: actions.fetchAll,
  deleteState: actions.Delete,
  fetchByDistrictId:actions.fetchByDistrictId,
  fetchByDivisonId:actions.fetchByDivisonId,
  fetchByUpazilaId:actions.fetchByUpazilaId
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(StockList));
