import clientTypeApi from "./clientTypeApi";
import axios from "axios";
export const ACTION_TYPES = {
  CREATE: "CREATE",
  UPDATE: "UPDATE",
  DELETE: "DELETE",
  FETCH_ALL: "FETCH_ALL",
};

const formateData = (data) => ({
  ...data,
});

export const fetchAll = () => (dispatch) => {
  clientTypeApi
    .clientType()
    .fetchAll()
    .then((response) => {
      console.log(response.data.result);
      dispatch({
        type: ACTION_TYPES.FETCH_ALL,
        payload: response.data.result,
      });
    })
    .catch((err) => console.log(err) + "error");
};

export const create = (data, onSuccess) => (dispatch) => {
  data = formateData(data);
  console.log(data);
  clientTypeApi
    .clientType()
    .create(data)
    .then((res) => {
      console.log(res);
      dispatch({
        type: ACTION_TYPES.CREATE,
        payload: res.data.result,
      });
      clientTypeApi
        .clientType()
        .fetchAll()
        .then((response) => {
          dispatch({
            type: ACTION_TYPES.FETCH_ALL,
            payload: response.data.result,
          });
        });

      onSuccess();
    })
    .catch((err) => console.log(err));
};

export const update = (id, data, onSuccess) => (dispatch) => {
  data = formateData(data);
  clientTypeApi
    .clientType()
    .update(id, data)
    .then((res) => {
      dispatch({
        type: ACTION_TYPES.UPDATE,
        payload: { id, ...data },
      });
      onSuccess();
    })
    .catch((err) => console.log(err));
};

export const Delete = (id, onSuccess) => (dispatch) => {
  clientTypeApi
    .clientType()
    .delete(id)
    .then((res) => {
      dispatch({
        type: ACTION_TYPES.DELETE,
        payload: id,
      });
      onSuccess();
    })
    .catch((err) => console.log(err));
};

export const getInitialData = () => {
  return async (dispatch) => {
    await axios
      .get("http://localhost:5001/api/clientType/get")
      .then((response) => {
        dispatch({ type: "GET_ALL_DATA", data: response.data });
      });
  };
};

export const filterData = (value) => {
  return (dispatch) => dispatch({ type: "FILTER_DATA", value });
};
