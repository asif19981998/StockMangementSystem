import {apiUrl} from "../../configs/config.json"
import axios from "axios";
function getDivison (){
    axios.get(apiUrl+"divison/").then(response=>{
        return response.data;
    })
    return "No data";
}

function getDistrict (){

   return axios.get(apiUrl+"district/")
    
    // return [];
}

function getUpazilaByDistrict (disId){
    
    return axios.get(apiUrl+"upazila/"+"GetByDistrictID/"+disId)
     
     // return [];
 }

function getUpazila (){
   return axios.get(apiUrl+"upazila/")
    // return [];
}

function getStockData(){
    return axios.get(apiUrl+"stock/"+"GetChartData")
}

export  {
    getDistrict,getDivison,getUpazila,getUpazilaByDistrict,getStockData
}