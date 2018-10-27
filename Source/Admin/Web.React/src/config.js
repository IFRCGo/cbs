const dev = {
    apiGateway : {
        URL : 'http://localhost:5000'
    }
  };
  
  const prod = {
    apiGateway : {
        URL : 'http://localhost:5000'
    }
  };
  
  const config = process.env.REACT_APP_STAGE === 'production'
    ? prod
    : dev;
  
  export default {
    // Add common config values here
    MAX_ATTACHMENT_SIZE: 5000000,
    ...config
  };

  // Based off : https://serverless-stack.com/chapters/environments-in-create-react-app.html