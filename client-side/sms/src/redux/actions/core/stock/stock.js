import * as baseActions from "../../base/baseActions/baseActions"
import stockApi from "./stockApi";
import { dataFetched,dataAdded,dataUpdated,dataDeleted } from "../../base/actionCreator";
export const ACTION_TYPES = {
    CREATE: "CREATE_STOCK",
    UPDATE: "UPDATE_STOCK",
    DELETE: "DELETE_STOCK",
    FETCH_ALL: "FETCH_ALL_STOCK",
  };

const formateData = data => ({
    ...data
})

const apiController = "stock/";

export const fetchAll = () => (dispatch) => {
    baseActions.fetchAll(apiController,ACTION_TYPES.FETCH_ALL,dispatch)
  };
   
   export const create = (data, onSuccess) => (dispatch) => {
    baseActions.create(apiController,data,onSuccess,ACTION_TYPES.CREATE,dispatch)
   };
   
   export const update = (id, data, onSuccess) => (dispatch) => {
     baseActions.update(apiController,id,data,onSuccess,ACTION_TYPES.UPDATE,dispatch)
   };
   
   export const Delete = (id, onSuccess) => (dispatch) => {
     baseActions.Delete(apiController,id,onSuccess,ACTION_TYPES.DELETE,dispatch)
   };

   export const fetchByDistrictId = (id) => (dispatch) =>{
    stockApi
    .stockHttp()
    .fetchByDistritId(id)
    .then((response) => {
      console.log(response.data)
      dispatch(dataFetched(ACTION_TYPES.FETCH_ALL,response.data));
     })
    .catch((err) => console.log(err) + "error")
   }
   export const fetchByUpazilaId = (id) => (dispatch) =>{
    stockApi
    .stockHttp()
    .fetchByUpazilaId(id)
    .then((response) => {
      console.log(response.data)
      dispatch(dataFetched(ACTION_TYPES.FETCH_ALL,response.data));
     })
    .catch((err) => console.log(err) + "error")
   }

   export const fetchByDivisonId = (id) => (dispatch) =>{
    stockApi
    .stockHttp()
    .fetchByDivisonId(id)
    .then((response) => {
      console.log(response.data)
      dispatch(dataFetched(ACTION_TYPES.FETCH_ALL,response.data));
     })
    .catch((err) => console.log(err) + "error")
   }

 



  
  
  