const fs = require('fs');
const path = require('path');

var copyRecursiveSync = function(src, dest) {
  var exists = fs.existsSync(src);
  var stats = exists && fs.statSync(src);
  var isDirectory = exists && stats.isDirectory();
  if (exists && isDirectory) {
    fs.mkdirSync(dest);
    fs.readdirSync(src).forEach(function(childItemName) {
      copyRecursiveSync(path.join(src, childItemName),
                        path.join(dest, childItemName));
    });
  } else {
    fs.linkSync(src, dest);
  }
};

fs.exists('./src/app/navigation/nav-top-bar/nav-top-bar.component.ts', result => {
    if( fs.existsSync('./src/app/navigation') ) {
        console.log('Navigation folder exists - unlink')
        fs.unlink('./src/app/navigation', (err) => {
            if( err ) console.log(err);
        });
    }

    if (!result) {
        console.log('Navigation symlink / folder does not exist - copy across');
        copyRecursiveSync('../../Navigation/', './src/app/navigation');
        console.log('All files copied');
    } else {
        console.log('Navigation symlink or folder exists - carry on');
    }
});
