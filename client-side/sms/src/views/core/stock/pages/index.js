import React, { useState, useEffect} from "react";
import { connect } from "react-redux";
import * as actions from "../../../../redux/actions/core/stock/stock";
import {  withStyles} from "@material-ui/core";

import { useToasts } from "react-toast-notifications";

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
  
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const headCells = [
    { id: 'name',propertyName:"name", numeric: false, disablePadding: true, label: 'Name' },
    { id: 'quantity',propertyName:"quantity", numeric: true, disablePadding: true, label: 'Quantity' },
    { id: 'upazila',propertyName:"upazilaName", numeric: true, disablePadding: true, label: 'Upazila' },
    { id: 'actions ',propertyName:"actions", numeric: true, disablePadding: true, label: 'Actions   D/E' },
  ];

 
  
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
    <div elevation={3}>
      {/* <div className="row">
       <EnhancedTable 
         title="Stock List" 
         formName="Stock"
         headCells={headCells} 
         rows={props.stockList}
         onDelete={onDelete}
         setCurrentId={setCurrentId}
         createForm="/stockCreate"/>
      </div> */}
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
