
function mapWidget(typeName = '') {
    return (state = {}, action) => {
      const { name } = action
      if (name !== typeName) return state
  
      switch (action.type) {
        case "FETCH_REQUEST":
          return state;
        case "FETCH_SUCCESS":
          return {
            ...state,
            payload: action.payload
          };
        default:
          return state;
      }
    }
  }
  
  export default mapWidget