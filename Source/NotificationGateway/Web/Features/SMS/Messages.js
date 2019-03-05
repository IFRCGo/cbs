import React from 'react';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { Guid } from '@dolittle/core';
import { Formik, Form, Field } from 'formik';

import { SimulateReceivedMessage } from './SimulateReceivedMessage';
import { AllReceivedMessages } from './AllReceivedMessages';

class Messages extends React.Component {
    constructor(props) {
        super(props);
        this.commandCoordinator = new CommandCoordinator()
        this.queryCoordinator = new QueryCoordinator();
        this.state = {
            messages: [],
        };
    }

    componentDidMount() {
        this.queryCoordinator.execute(new AllReceivedMessages()).then(result => {
            if (result.success) {
                this.setState({
                    messages: result.items,
                });
            }
        });
    }

    render() {
        return (
            <React.Fragment>
                <h2>Simulate message:</h2>
                <Formik
                    initialValues={{ phonenumber: '', message: '' }}

                    onSubmit={(values, { setSubmitting }) => {
                        const command = new SimulateReceivedMessage();
                        command.id = Guid.create();
                        command.sender = values.phonenumber;
                        command.text = values.message;
                        command.received = new Date();
                        this.commandCoordinator.handle(command).then(result => {
                            if (result.success) {
                                // Add the message here as well
                                this.setState((state) => { return {
                                    messages: [{
                                        sender: command.sender,
                                        text: command.text,
                                        received: command.received.toISOString(),
                                    }].concat(state.messages)
                                }})
                            }
                            values.phonenumber = '';
                            values.message = '';
                            setSubmitting(false);
                        });
                    }}
                >
                {({isSubmitting}) => (
                    <Form>
                        <Field name="phonenumber" type="tel" placeholder="+1 804 555 0101" disabled={isSubmitting} />
                        <br/>
                        <Field name="message" component="textarea" rows="5" placeholder="Write message here..." disabled={isSubmitting} />
                        <br/>
                        <button type="submit" disabled={isSubmitting}>Send</button>
                    </Form>
                )}
                </Formik>

                <h2>All received messages:</h2>
                {
                    this.state.messages.map((message,i) => (
                        <React.Fragment key={i}>
                            <pre>
                                From: {message.sender+'\n'}
                                Received: {message.received+'\n'}
                                {message.text}
                            </pre>
                            <hr />
                        </React.Fragment>
                    ))
                }
            </React.Fragment>
        );
    }
}

export default Messages;
