import React from 'react';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { Guid } from '@dolittle/core';
import { Formik, Form, Field } from 'formik';
import { SmsGatewayGetAllQuery } from './SmsGatewayGetAllQuery';
import { RegisterSmsGateway } from './RegisterSmsGateway';
import { AssignPhoneNumberToSmsGateway } from './AssignPhoneNumberToSmsGateway';

class Gateways extends React.Component {
    constructor(props) {
        super(props);
        this.commandCoordinator = new CommandCoordinator()
        this.queryCoordinator = new QueryCoordinator();
        this.state = {
            gateways: [],
        };
    }

    componentDidMount() {
        this.queryCoordinator.execute(new SmsGatewayGetAllQuery()).then(result => {
            if (result.success) {
                this.setState({
                    gateways: result.items,
                });
            }
        });
    }

    render() {
        return (
            <React.Fragment>
                <h2>Registered gateways:</h2>
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Enabled</th>
                            <th>Number</th>
                            <th>ApiKey</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.gateways.map((gateway,i) => (
                                <tr key={gateway.id}>
                                    <td>{gateway.name}</td>
                                    <td>{gateway.enabled ? '\u2705' : '\u274C'}</td>
                                    <td>
                                        <Formik
                                            initialValues={{ phonenumber: gateway.phoneNumber || '' }}

                                            onSubmit={(values, { setSubmitting }) => {
                                                const command = new AssignPhoneNumberToSmsGateway();
                                                command.smsGatewayId = gateway.id;
                                                command.phoneNumber = values.phonenumber;
                                                this.commandCoordinator.handle(command).then(result => {
                                                    if (result.success) {
                                                        this.setState((state) => { return {
                                                            gateways: state.gateways.map(oldgw => {
                                                                if (oldgw.id == gateway.id) {
                                                                    oldgw.phoneNumber = command.phoneNumber;
                                                                    oldgw.enabled = true;
                                                                }
                                                                return oldgw;
                                                            })
                                                        }})
                                                    }
                                                    setSubmitting(false);
                                                });
                                            }}
                                        >
                                        {({isSubmitting}) => (
                                            <Form>
                                                <Field name="phonenumber" type="tel" placeholder="Phonenumber" disabled={isSubmitting} />
                                                <button type="submit" disabled={isSubmitting}>Save</button>
                                            </Form>
                                        )}
                                        </Formik>
                                    </td>
                                    <td>{gateway.apiKey}</td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>

                <h2>Add new gateway:</h2>
                <Formik
                    initialValues={{ name: '' }}

                    onSubmit={(values, { setSubmitting }) => {
                        const command = new RegisterSmsGateway();
                        command.smsGatewayId = Guid.create();
                        command.name = values.name;
                        this.commandCoordinator.handle(command).then(result => {
                            if (result.success) {
                                this.setState((state) => { return {
                                    gateways: [{
                                        id: command.smsGatewayId,
                                        name: command.name,
                                        enabled: false,
                                        phoneNumber: '',
                                        apiKey: 'Generating...'
                                    }].concat(state.gateways)
                                }})
                            }
                            setSubmitting(false);
                        });
                    }}
                >
                {({isSubmitting}) => (
                    <Form>
                        <Field name="name" placeholder="Name of gateway" disabled={isSubmitting} />
                        <button type="submit" disabled={isSubmitting}>Register</button>
                    </Form>
                )}
                </Formik>
                
            </React.Fragment>
        );
    }
}

export default Gateways;
