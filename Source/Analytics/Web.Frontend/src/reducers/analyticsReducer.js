const baseState = {
  chart: {
    type: 'column'
  },
  subtitle: {
    text: 'Source: CSB'
  },
  xAxis: {
    categories: [],
    crosshair: true
  },
  yAxis: {
    min: 0,
    title: {
      text: 'Number in cases in total'
    }
  },
  plotOptions: {
    column: {
      pointPadding: 0.1,
      borderWidth: 0
    }
  },

  options: {
    barPercentage: 1.0,
    categoryPercentage: 1.0
  },

  series: []
}

function analytics(typeName = '') {
  return (state = baseState, action) => {
    const { name } = action
    if (name !== typeName) return state

    switch (action.type) {
      case "FETCH_REQUEST":
        return state;
      case "FETCH_SUCCESS":
        return {
          ...state,
          series: action.payload.series,
          xAxis: { categories: action.payload.categories }
        };
      default:
        return state;
    }
  }
}

export default analytics