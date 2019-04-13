import { combineReducers } from "redux";
import analytics from "./analyticsReducer";

export default combineReducers({
    analytics: analytics()
});
