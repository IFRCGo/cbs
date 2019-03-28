
function kpiReducer() {
    return (state = {}, action) => {
      
      switch (action.type) {
        case "FETCH_REQUEST_KPI":
          return state;
        case "FETCH_SUCCESS_KPI":
          return {
            ...state,
            payload: action.payload
          };
        default:
          return state;
      }
    }
  }
  
  export default kpiReducer