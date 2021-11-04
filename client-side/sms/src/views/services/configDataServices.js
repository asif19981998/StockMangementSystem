import {apiUrl} from "../../configs/config.json"
import axios from "axios";
function getDivison (){
    return axios.get(apiUrl+"divison/")
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