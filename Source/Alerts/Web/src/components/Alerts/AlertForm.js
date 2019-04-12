import React, { Component } from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { connect } from 'react-redux';


import MenuAlert from './menuAlert';


const styles = theme => ({
    container: {
      display: 'flex',
      flexWrap: 'wrap',
    },
    button: {
        margin: theme.spacing.unit,
      },
      input: {
        display: 'none',
      },
    
  });
  
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
                    <MenuAlert  />
                <div style={{ textAlign:'center' }}>
                    <h1 >Alert Rule</h1>
                    <p>Here you can set rules for health risk alerts.</p>
                </div>
                <TextField className="input"
                    id=""
                    label="Alert rule name"
                    style={{ marginLeft:'15%',width:'70%',  }}
                    defaultValue="i.e. Acute watery diarrhoea"
                    fullWidth
                    margin="normal"
                    variant="outlined"
                    
                />
                
                  <TextField
                    id="filled-full-width"
                    label="Health risk number"
                    type="number"
                    name="risk_number"
                    style={{ marginLeft:'15%',width:'35%',  }}
                    defaultValue="1"
                    fullWidth
                    margin="normal"
                    variant="outlined"
                    
                />
             
                 <TextField
                    id="filled-full-width"
                    label="Alert threshold"
                    type="text"
                    defaultValue="Write the number of cases to rise an alert"
                    name="risk_number"
                    style={{ marginLeft:'0.2%',width:'35%',  }}
                    placeholder="i.e. 2"
                    fullWidth
                    margin="normal"
                    variant="outlined"
                
                />
                <TextField
                    id="filled-full-width"
                    label="Threshold timeframe (in hours)"
                    type="text"
                    name="risk_number"
                    style={{ marginLeft:'15%',width:'70%'}}
                    defaultValue="Define the time from case 1 to the alert threshold is reached."
                    fullWidth
                    margin="normal"
                    variant="outlined"
               
                />
                <Button
                 variant="contained"
                 style={{ marginLeft:'15%',
                 width:'5%',
                 marginTop:'2%',

                }}
                 >
                    Cancel
                </Button>
                <Button variant="contained"
                   style={{ 
                     marginLeft:'2%',
                     marginTop:'2%',
                     width:'5%',
                     backgroundColor:'blue'

                    }} >
                    Save  
                </Button>
                                        
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
