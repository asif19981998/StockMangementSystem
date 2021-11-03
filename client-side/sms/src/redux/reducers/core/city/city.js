const initialState = {
  list: [],
};
export const ACTION_TYPES = {
  CREATE: "CREATE_CITY",
  UPDATE: "UPDATE_CITY",
  DELETE: "DELETE_CITY",
  FETCH_ALL: "FETCH_ALL_CITY",
};


 export const city = (state = initialState , action) => {
  switch (action.type) {
    case ACTION_TYPES.FETCH_ALL:
      return {
        ...state,
        list: [...action.payload]
      };

    case ACTION_TYPES.CREATE:
      return {
        ...state,
        list: [...state.list, action.payload],
      };

    case ACTION_TYPES.UPDATE:
      return {
        ...state,
        list: state.list.map((x) =>
          x.id === action.payload.id ? action.payload : x
        ),
      };

    case ACTION_TYPES.DELETE:
      return {
        ...state,
        list: state.list.filter((x) => x.id !== action.payload),
      };

    default:
      return state;
  }
};


