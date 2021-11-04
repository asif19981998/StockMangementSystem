
import React,{useEffect,useState} from "react";
import axios from "axios"
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
import StockTable from "../../common/component/stockTable"
import StockService from "../../services/stockService";
import NoDataFound from "../../common/component/noDataFound";
   const stockService = new StockService();
function StockBarChart(props) {
    const [stockData,setStockData]=useState([])
    const [targetItem,setTargetItem]=useState(undefined)
    const [chartData,setChartData]=useState(stockService.data);
    const [upazilaStockData,setUpazilaStockData]=useState([])
    const [showListData,setShowListData]= useState(false)
      useEffect(()=>{
        props.fetchAllStock()
        //   setStockData(props.stockList)
        //   console.log(stockData)
       
        getStockData().then(response=>{
            response.data.forEach(element => {
                console.log(element)
                var data = {
                    upazilaId:element.upazilaId,
                    quantity:element.quantity,
                    upazilaName:element.upazila.name
                }
                 setChartData(chartData.concat(data))
                 console.log(data)
                 console.log(chartData+"ghghgh")
            });
        })
       
      },[])


      const clickbarChart =(e)=>{
        console.log(chartData)
        var index = e.targets[0].point
        var id = chartData[index].upazilaId
        axios.get("https://localhost:44388/api/stock/GetByUpazilaID/"+id).then(response=>{

          setUpazilaStockData(response.data)
          setShowListData(true)
        }
        )
       
      }
      const changeTargetItem=(targetItem)=>{
        setTargetItem(targetItem)
       
      }

      const test=()=>{
          console.log(chartData)
      }
  if(showListData){
    return(
      <StockTable data={upazilaStockData} setShowTable={setShowListData}></StockTable>
    )
  }
   
        return (
           <Paper>
        {chartData.length == 0 && <NoDataFound></NoDataFound>}
       {!chartData.length == 0 &&   <Chart
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
          
        </Chart>} 
     
        
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
  