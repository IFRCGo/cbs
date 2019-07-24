To run:
1. In this folder, run `npm link`
2. In the web folder you want to use, run `npm link ../../Web.React` so that you create a reference back to this folder

To update: 
Run `babel index.js lib/index.js`. The node module listens to the transpiled lib-file. As the navbar has no Webpack setup, babel must be called manually to transpile. 