import { combineReducers } from 'redux'
import analytics from './analyticsReducer'
import counters from './counterReducer'
import mapWidget from './mapWidgetReducer'

export default combineReducers({
  epicurveByDay: analytics("Day"),
  epicurveByWeek: analytics("Week"),
  epicurveByWeekByAge: analytics("WeekByAge"),
  map: mapWidget(),
  counters
})