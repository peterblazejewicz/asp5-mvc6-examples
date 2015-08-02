/* jshint -W097 */
'use strict';
/// <binding Clean='clean' />

/* jshint node: true */
var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify"),
  project = require("./project.json");

var paths = {
  webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "scripts/**/*.js";
paths.minJs = paths.webroot + "scripts/**/*.min.js";
paths.css = paths.webroot + "styles/**/*.css";
paths.minCss = paths.webroot + "styles/**/*.min.css";
paths.concatJsDest = paths.webroot + "scripts/site.min.js";
paths.concatCssDest = paths.webroot + "styles/site.min.css";

gulp.task("clean:js", function(cb) {
  rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function(cb) {
  rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function() {
  gulp.src([paths.js, "!" + paths.minJs], {
      base: "."
    })
    .pipe(concat(paths.concatJsDest))
    .pipe(uglify())
    .pipe(gulp.dest("."));
});

gulp.task("min:css", function() {
  gulp.src([paths.css, "!" + paths.minCss])
    .pipe(concat(paths.concatCssDest))
    .pipe(cssmin())
    .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);
