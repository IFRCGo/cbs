import { combineReducers } from 'redux'
import analytics from './analyticsReducer'
import counters from './counterReducer'

export default combineReducers({
  epicurveByDay: analytics("Day"),
  epicurveByWeek: analytics("Week"),
  epicurveByWeekByAge: analytics("WeekByAge"),
  counters
})