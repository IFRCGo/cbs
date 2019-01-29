import React, { Component } from 'react';
import Nav from '../Nav';
import ProjectForm from './ProjectForm';

const AddProjectPage = () => {
    return (
        <article id="projects-list">
            <section className="container">
                <Nav />
                <ProjectForm />
            </section>
        </article>
    )
};


export default AddProjectPage;
