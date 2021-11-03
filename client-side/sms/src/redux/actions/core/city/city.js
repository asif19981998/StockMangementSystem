import * as baseActions from "../../base/baseActions/baseActions"

export const ACTION_TYPES = {
  CREATE: "CREATE_CITY",
  UPDATE: "UPDATE_CITY",
  DELETE: "DELETE_CITY",
  FETCH_ALL: "FETCH_ALL_CITY",
};

const apiController = "city/"

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