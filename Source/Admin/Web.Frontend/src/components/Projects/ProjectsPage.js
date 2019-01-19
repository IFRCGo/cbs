import React from 'react';
import ListHeader from './ListHeader';
import ProjectsList from './ProjectsList';
import Nav from '../Nav';

const Projects = () => {
    return (
        <div>
            <Nav />
            <ListHeader />
            <ProjectsList />
        </div>
    );
};

export default Projects;
