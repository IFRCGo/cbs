import React, { Component } from "react";
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

class TotalCard extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <Card>
            <div>
              <CardContent>
              {this.props.className && (
                         <i className={this.props.className} />
                )}
              <Typography variant="subtitle1" color="textSecondary">
                  {this.props.subTitle}
                </Typography>
                <Typography component="h5" variant="h5">
                {this.props.total}
                </Typography>
              </CardContent>
            </div>
           
          </Card>
        );
    }
}

export default TotalCard;
