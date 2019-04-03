import { combineReducers } from "redux";
import analytics from "./analyticsReducer";
import mapWidget from "./mapWidgetReducer";
import kpiReducer from "./kpiReducer";

export default combineReducers({
    epicurveByDay: analytics("Day"),
    epicurveByWeek: analytics("Week"),
    epicurveByWeekByAge: analytics("WeekByAge"),
    map: mapWidget(),
    kpi: kpiReducer(),
    epicurvebyweekGrid: analytics("WeekGrid"),
    epicurvebyweekGrid2: analytics("WeekGrid2"),
    epicurvebyweekGrid3: analytics("WeekGrid3"),
    epicurvebyweekGrid4: analytics("WeekGrid4")
});
