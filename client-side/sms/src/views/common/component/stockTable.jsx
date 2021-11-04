import React,{useEffect} from "react";

import {Card,CardHeader,CardTitle,CardBody,FormGroup,Label,Input} from "reactstrap";





const StockTable = (props) => {
 let tableData = [];
 useEffect (()=>{
    // props.data.forEach(element => {
    //     var data = {
    //         upazilaId:element.upazilaId,
    //         quantity:element.quantity,
    //         upazilaName:element.upazila.name
    //     }
    //     tableData.push(data)
    // })
    // console.log(props.data);

 })
  return (

    <Card>
      <CardHeader>

        <CardTitle>Stock Details </CardTitle>
        <a style={{marginLeft:"68%"}} class="btn btn-info" onClick={()=>props.setShowTable(false)}>Show Chart Data</a>
        <a href="https://localhost:44388/api/stock/getReport" target="_blank" class="btn btn-success">Download Pdf</a>
        
     
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
   
    {props.data.map(stock=>(
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



export default StockTable;

