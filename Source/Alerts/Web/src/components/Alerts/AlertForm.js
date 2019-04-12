import React, { Component } from 'react';
import TextField from '@material-ui/core/TextField';

import { connect } from 'react-redux';


const styles = theme => ({
    container: {
      display: 'flex',
      flexWrap: 'wrap',
    },
    textField: {
      marginLeft: theme.spacing.unit,
      marginRight: theme.spacing.unit,
    },
    dense: {
      marginTop: 16,
    },
    menu: {
      width: 200,
    },
  });
  const healthRiskNumber = [
    {
      value: '1',
      label: '1',
    },
    {
      value: '2',
      label: '2',
    },
    {
      value: '3',
      label: '3',
    },
    {
      value: '4',
      label: '4',
    },
  ];

class AlertForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            alertRuleName: "",
            healthRiskNumber: "",
            numberOfCasesThreshold: "",
            thresholdTimeframeInHours: ""
        };
    }
    handleChange = name => event => {
        this.setState({
          [name]: event.target.value,
        });
      };

    addRule() {
        let request = {
            ...new CreateAlertRule(),
            alertRuleName: this.state.alertRuleName,
            healthRiskNumber: this.state.healthRiskNumber,
            numberOfCasesThreshold: this.state.numberOfCasesThreshold,
            thresholdTimeframeInHours: this.state.thresholdTimeframeInHours
        };

        this.props.requestCreateRule(request);
        this.resetState();
    }

    resetState() {
        this.setState({
            alertRuleName: "",
            healthRiskNumber: "",
            numberOfCasesThreshold: "",
            thresholdTimeframeInHours: ""
        });
    }
  
    render() {
        const { classes } = this.props;

        return (
            <div className="">
                <h1>Alert Rule</h1>
                <p>Here you can set rules for health risk alerts.</p>
             
                <TextField
                    id="filled-full-width"
                    label="Alert rule name"
                    style={{ margin: 8 }}
                    placeholder="i.e. Acute watery diarrhoea"
                    fullWidth
                    margin="normal"
                    variant="filled"
                    InputLabelProps={{
                        shrink: true,
                    }}
                />
                  <TextField
                    id="filled-full-width"
                    label="Health risk number"
                    type="text"
                    name="risk_number"
                    style={{ margin: 8 }}
                    placeholder="i.e. 1"
                    fullWidth
                    margin="normal"
                    variant="filled"
                    InputLabelProps={{
                        shrink: true,
                    }}
                />
             
                 <TextField
                    id="filled-full-width"
                    label="Alert threshold"
                    type="text"
                    name="risk_number"
                    style={{ margin: 8 }}
                    placeholder="i.e. 2"
                    fullWidth
                    margin="normal"
                    variant="filled"
                    InputLabelProps={{
                        shrink: true,
                    }}
                />
                <TextField
                    id="filled-full-width"
                    label="Threshold timeframe (in hours)"
                    type="text"
                    name="risk_number"
                    style={{ margin: 8 }}
                    placeholder="i.e. 24"
                    fullWidth
                    margin="normal"
                    variant="filled"
                    InputLabelProps={{
                        shrink: true,
                    }}
                />

               
            </div>
        );
    }
}

export default connect(
    _ => ({}),
    dispatch => ({
        requestCreateRule: rule => dispatch({ type: 'REQUEST_CREATE_RULE', payload: rule }),
    }))
    (AlertForm);
