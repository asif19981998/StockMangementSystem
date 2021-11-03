
import React,{useEffect,useState} from "react";
import Paper from '@material-ui/core/Paper';
import {
  ArgumentAxis,
  ValueAxis,
  Chart,
  BarSeries,
  Title,
  Tooltip
} from '@devexpress/dx-react-chart-material-ui';
import * as actions from "../../../redux/actions/core/stock/stock";
import {fetchAllStock} from "../../../redux/actions/core/stock/stock";
import { EventTracker } from '@devexpress/dx-react-chart';
import { connect } from "react-redux";
import {getStockData} from "../../services/configDataServices"
import StockService from "../../services/stockService";
   const stockService = new StockService();
function StockBarChart(props) {
    const [stockData,setStockData]=useState([])
    const [targetItem,setTargetItem]=useState(undefined)
    const [chartData,setChartData]=useState(stockService.data);
    // var chartData = [];
    const data = [
        {quantity: 224, upazilaName: 'Kishoreganj Sadar'},
        {quantity: 326, upazilaName: 'Bhairab'}
        
      ];

      useEffect(()=>{
        props.fetchAllStock()
        //   setStockData(props.stockList)
        //   console.log(stockData)
       
        getStockData().then(response=>{
            response.data.forEach(element => {
                var data = {
                    quantity:element.quantity,
                    upazilaName:element.upazila.name
                }
                 setChartData(chartData.concat(data))
                 console.log(data)
                 console.log(chartData)
            });
        })
       
      },[])


      const clickbarChart =(e)=>{
        console.log(e.targets[0].point)
        console.log(e)
       
      }
      const changeTargetItem=(targetItem)=>{
        setTargetItem(targetItem)
        console.log(targetItem)
      }

      const test=()=>{
          console.log(chartData)
      }

   
        return (
            <Paper>
     
        <Chart
          data={chartData}
        >
          <ArgumentAxis />
          <ValueAxis  />
          <BarSeries valueField="quantity" argumentField="upazilaName"    />
          <Title
                text="Product Quantity (upazila)"
              />
          <EventTracker onClick={clickbarChart}/>
          <Tooltip targetItem={targetItem} onTargetItemChange={changeTargetItem}/>
          
        </Chart>
        
      </Paper>
        )
    
    
}
const mapStateToProps = state => ({
    stockList: state.stock.list
  })
  
  const mapActionToProps = {
    fetchAllStock: actions.fetchAll,
  }
  
  export default connect(mapStateToProps, mapActionToProps)(StockBarChart);
  