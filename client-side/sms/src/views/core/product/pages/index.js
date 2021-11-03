import React, { useState, useEffect} from "react";


import * as actions from "../../../../redux/actions/core/product/product";
import {  withStyles} from "@material-ui/core";
import { connect } from "react-redux";
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

const ProductList = ({ classes, ...props }) => {
  const [currentId, setCurrentId] = useState(0)
  const [page, setPage] = React.useState(0);
  const [product,setProduct]=useState([]);
  
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const headCells = [
    { id: 'name',propertyName:"name", numeric: false, disablePadding: true, label: 'Name' },
    { id: 'code',propertyName:"code", numeric: true, disablePadding: true, label: 'Code' },
    { id: 'actions ',propertyName:"actions", numeric: true, disablePadding: true, label: 'Actions   D/E' },
  ];

 
  
  useEffect(() => {
      props.fetchAllProduct()
     
     setProduct(props.productList)
      
    
     },[product] )


  const { addToast } = useToasts()

  const onDelete = id => {
    console.log(id);
    if (window.confirm('Are you sure to delete this record?'))
      props.deleteProduct(id, () => addToast("Deleted successfully", { appearance: 'info' }))
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
      <div className="row">
       <EnhancedTable 
         title="Product List" 
         formName="Product"
         headCells={headCells} 
         rows={props.productList}
         onDelete={onDelete}
         setCurrentId={setCurrentId}
         createForm="/productCreate"/>
      </div>
    </div>
  
  
  );
}

const mapStateToProps = state => ({
  productList: state.product.list
})

const mapActionToProps = {
  fetchAllProduct: actions.fetchAll,
  deleteProduct: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(ProductList));
