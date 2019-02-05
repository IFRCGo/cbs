import Projects from "../components/Projects";
import Analytics from "../components/Analytics";

export const routes = [
    {
        component: Projects,
        path: '/projects/',
        exact: false
    },
    {
        component: Analytics,
        path: '/analytics/',
        exact: false
    }
];