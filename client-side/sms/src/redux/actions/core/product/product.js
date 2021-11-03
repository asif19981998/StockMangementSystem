import * as baseActions from "../../base/baseActions/baseActions"

export const ACTION_TYPES = {
  CREATE: "CREATE_PRODUCT",
  UPDATE: "UPDATE_PRODUCT",
  DELETE: "DELETE_PRODUCT",
  FETCH_ALL: "FETCH_ALL_PRODUCT",
};

const apiController = "product/";

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



