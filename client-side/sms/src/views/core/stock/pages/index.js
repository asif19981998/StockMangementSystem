import React, { useState, useEffect} from "react";
import { connect } from "react-redux";
import * as actions from "../../../../redux/actions/core/stock/stock";
import {  withStyles} from "@material-ui/core";
import {Card,CardHeader,CardTitle,CardBody,FormGroup,Label,Input} from "reactstrap";
import { useToasts } from "react-toast-notifications";
import axios from "axios";
import EnhancedTable from "../../../common/component/table";

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
  // const[List,setUpazilaList]=useState([])
  
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  

 
  
  useEffect(() => {
      props.fetchAllStock()
     
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
   </tr>
 </thead>
 <tbody>
   
    {props.stockList.map(stock=>(
      <tr>
      <td>{stock.product?.name ?? "N/A"}</td>
      <td>{stock.quantity ?? "N/A"}</td>
      <td>{stock.upazila?.name ?? "N/A"}</td>
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
  deleteState: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(StockList));
