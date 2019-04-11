import { combineReducers } from "redux";
import reporting from "./reportingReducer";

export default combineReducers({
    reporting: reporting()
});
