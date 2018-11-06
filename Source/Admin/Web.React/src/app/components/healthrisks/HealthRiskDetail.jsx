import React from 'react';

class HealthRiskDetail extends React.Component{


    constructor(props) {
        super(props);
        this.state = { elements: [] };
    }

    render() { 
        return (
            <form ngNativeValidate class="form-horizontal">
                <div class="form-group">
                    <label class="control-label col-sm-3" for="healthRiskNumber">Health risk number:</label>
                    <div class="col-sm-9">

                    </div>
                </div>
            </form>
        )
    } 
}

export default HealthRiskDetail; 