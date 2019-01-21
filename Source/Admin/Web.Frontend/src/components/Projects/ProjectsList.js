import React, { Component } from 'react';
import { Table } from 'evergreen-ui';
import ProjectListItem from './ProjectListItem';

// NEED THIS TO GET QUERY TO WORK IT TO WORK
import { QueryCoordinator } from '@dolittle/queries';

// Import the wanted class model you want to query
import { AllProjects } from '../../dolittle/Projects/AllProjects';

export default class ProjectsList extends Component {
    constructor(props) {
        super(props);

        this.state = {
            data: [],
            fakeData: [
                {
                    projectName: 'Project One',
                    dataOwner: 'Data Owner One',
                    geographicalScope: 'Scope One',
                    healthRisk: 'Health risk One'
                },
                {
                    projectName: 'Project Two',
                    dataOwner: 'Data Owner Two',
                    geographicalScope: 'Scope Two',
                    healthRisk: 'Health risk Two'
                },
                {
                    projectName: 'Project Three',
                    dataOwner: 'Data Owner Three',
                    geographicalScope: 'Scope Three',
                    healthRisk: 'Health risk Three'
                },
                {
                    projectName: 'Project Four',
                    dataOwner: 'Data Owner Four',
                    geographicalScope: 'Scope Four',
                    healthRisk: 'Health risk Four'
                }
            ]
        };

        // You need to set apiBaseUrl to localhost (not the new instance underneath)
        QueryCoordinator.apiBaseUrl = 'http://localhost:5001';
        this.queryCoordinator= new QueryCoordinator();
        this.query = new AllProjects();
    }

    componentDidMount() {
        this.queryCoordinator.execute(this.query)
            .then(response => {
                if (response.success) {
                    console.log(response);
                    this.setState({
                        data: response.items
                    });
                } else {
                    console.error(response);
                }
            })
            .catch(response => {
                console.error(response);
            });
    }

    render() {
        return (
            <Table marginBottom={32}>
                <Table.Head>
                    <Table.TextHeaderCell>Project name</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Data owner</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Geographical scope</Table.TextHeaderCell>
                    <Table.TextHeaderCell>Health risks</Table.TextHeaderCell>
                </Table.Head>

                <Table.Body height={240}>
                    {
                        this.state.fakeData.map((data, i) => {
                            return <ProjectListItem key={i} data={data}/>;
                        })
                    }
                </Table.Body>
            </Table>
        );
    }
};
