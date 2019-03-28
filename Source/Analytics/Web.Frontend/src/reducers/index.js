import { combineReducers } from 'redux'
import analytics from './analyticsReducer'
import counters from './counterReducer'
import mapWidget from './mapWidgetReducer'
import kpiReducer from './kpiReducer'

export default combineReducers({
  epicurveByDay: analytics("Day"),
  epicurveByWeek: analytics("Week"),
  epicurveByWeekByAge: analytics("WeekByAge"),
  map: mapWidget(),
  kpi: kpiReducer(),
  epicurvebyweekGrid: analytics("WeekGrid"),
  epicurvebyweekGrid2: analytics("WeekGrid2"),
  epicurvebyweekGrid3: analytics("WeekGrid3"),
  epicurvebyweekGrid4: analytics("WeekGrid4"),
  counters,
  
})