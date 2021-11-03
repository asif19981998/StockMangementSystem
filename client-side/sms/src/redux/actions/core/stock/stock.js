import * as baseActions from "../../base/baseActions/baseActions"
import baseApi from "../../../actions/base/baseActions/baseApi"

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

//    export const fetchAllStock=(dispatch)=>{
//      (baseApi
//         .baseHttp("stock/") 
//         .fetchAll()
//         .then((response) => {
//           console.log(response.data)
//           dispatch(dataFetched(actionType,response.data));
//          })
//         .catch((err) => console.log(err) + "error")
//         )
//    }
  
  
  