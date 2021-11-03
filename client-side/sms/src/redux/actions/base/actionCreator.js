export const dataFetched =(actionType,data)=>({
    type:actionType,
    payload: data,
})

export const dataAdded =(actionType,data)=>({
    type: actionType,
    payload: data,
  })

export const dataUpdated =(actionType,id,data)=>({
    type:actionType,
    payload: { id, ...data },
  })
export const dataDeleted =(actionType,id)=>({
    type:actionType,
    payload: id,
  })

