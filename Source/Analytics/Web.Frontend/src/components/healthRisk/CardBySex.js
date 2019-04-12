import React, { Component } from "react";
import { getJson } from "../../utils/request";
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';

class CardBySex extends Component {
    constructor(props) {
        super(props);

        this.state = {
            healthRisks: [],
            isLoading: true,
            isError: false
        };
    }

    fetchData() {
        this.url = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRiskPerGender';
        //this.url = `${BASE_URL}KPI/${formatDate(from)}/${formatDate(to)}/`;

        //this.setState({ isLoading: true });

        getJson(this.url)
            .then(json =>
                this.setState({
                    female: json.female,
                    male: json.male,
                    isLoading: false,
                    isError: false
                })
            )
            .catch(_ =>
                this.setState({
                    isLoading: false,
                    isError: true
                })
            );
    }

    componentDidMount() {
        this.fetchData();
    }

    render() {
        return (
            <Card>
            <div>
              <CardContent>
              <i className=" fa fa-female" />
              <Typography variant="subtitle1" color="textSecondary">
                  Female
                </Typography>
                <Typography component="h5" variant="h5">
                  375
                </Typography>
              </CardContent>
            </div>
           
          </Card>
        );
    }
}

export default CardBySex;
