import React, { Component } from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { connect } from 'react-redux';
import { CreateAlertRule } from '../../../Features/AlertRules/CreateAlertRule';


import MenuAlert from '../menuAlert';

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
               <form onSubmit={this.handleSubmit}>
                <div style={{ textAlign:'center' }}>
                    <h1 >Alert Rule</h1>
                    <p>Here you can set rules for health risk alerts.</p>
                </div>
                <TextField className="input"
                    id=""
                    label="Alert rule name"
                    style={{ marginLeft:'35%',width:'35%',  }}
                    placeholder="i.e. Acute watery diarrhoea"
                    fullWidth
                    margin="normal"
                    variant="outlined"
                    onChange={e => this.setState({alertRuleName: e.target.value})}
                    value={this.state.alertRuleName} 
                />
                <br></br>
                
                  <TextField
                    id="filled-full-width"
                    label="Health risk number"
                    type="number"
                    name="risk_number"
                    style={{ marginLeft:'35%',width:'35%',  }}
                    placeholder="1"
                    fullWidth
                    margin="normal"
                    variant="outlined"
                    onChange={e => this.setState({healthRiskNumber: e.target.value})}
                    value={this.state.healthRiskNumber}
                    
                />
                <br></br>
             
                 <TextField
                    id="filled-full-width"
                    label="Alert threshold"
                    type="number"
                    placeholder="Write the number of cases to rise an alert"
                    name="risk_number"
                    style={{ marginLeft:'35%',width:'35%',  }}
                    placeholder="i.e. 2"
                    fullWidth
                    margin="normal"
                    variant="outlined"
                    onChange={e => this.setState({numberOfCasesThreshold: e.target.value})}
                    value={this.state.numberOfCasesThreshold}
                
                />
                <br></br>
                <TextField
                    id="filled-full-width"
                    label="Threshold timeframe (in hours)"
                    type="number"
                    name="risk_number"
                    style={{ marginLeft:'35%',width:'35%'}}
                    placeholder="Define the time from case 1 to the alert threshold is reached."
                    fullWidth
                    margin="normal"
                    variant="outlined"
                    onChange={e => this.setState({thresholdTimeframeInHours: e.target.value})}
                    value={this.state.thresholdTimeframeInHours}
               
                />
                <br></br>
                <Button
                 variant="contained"
                 onClick={() => this.resetState()}
                 style={{ marginLeft:'35%',
                 width:'5%',
                 marginTop:'2%',

                }}
                 >
                    Cancel
                </Button>
                <Button variant="contained"
                onClick={() => this.addRule()}
                   style={{ 
                     marginLeft:'3%',
                     marginTop:'2%',
                     width:'5%',
                     backgroundColor:'blue'

                    }}
                  
                     >
                    Save  
                </Button>
                </form>
                       
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
