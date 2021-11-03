import axios from "axios";
import baseApi from "./baseApi"
import { dataFetched,dataAdded,dataUpdated,dataDeleted } from "../actionCreator";
const formateData = (data) => ({
  ...data,
});



export function fetchAll(controllerName,actionType,dispatch){
    return (baseApi
    .baseHttp(controllerName) 
    .fetchAll()
    .then((response) => {
      console.log(response.data)
      dispatch(dataFetched(actionType,response.data));
     })
    .catch((err) => console.log(err) + "error")
    )
} 

export function create (controllerName,data, onSuccess,actionType,dispatch) {
  data = formateData(data);
  return (
    baseApi
    .baseHttp(controllerName)
    .create(data)
    .then((response) => {
      dispatch(dataAdded(actionType,response.data));
      onSuccess();
    })
    .catch((err) => console.log(err))
  )
};

export function update (controllerName,id, data, onSuccess,actionType,dispatch) {
  data = formateData(data);
  return(baseApi
    .baseHttp(controllerName)
    .update(id, data)
    .then((res) => {
      dispatch(dataUpdated(actionType,id,data));
      onSuccess();
    })
    .catch((err) => console.log(err))
  )
};

export function Delete (controllerName,id, onSuccess,actionType,dispatch)  {
  return (baseApi
    .baseHttp(controllerName)
    .delete(id)
    .then((res) => {
      dispatch(dataDeleted(actionType,id));
      onSuccess();
    })
    .catch((err) => console.log(err))
  )
};


