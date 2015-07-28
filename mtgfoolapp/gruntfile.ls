_ = require 'prelude-ls'
module.exports = (grunt) ->
  grunt.initConfig do
    pkg: grunt.file.readJSON 'package.json'

    uglify:
      options:
        banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd") %> */\n'
      build:
        src: 'src/<%= pkg.name %>.js'
        dest: 'build/<%= pkg.name %>.min.js'

    deadscript:
      build:
        expand: true,
        cwd: './src',
        src: ['**/*.ls'],
        dest: './site',
        ext: '.js'
        extDot : 'last'

    copy:
      all:
        files: [
         * expand: true
           cwd: 'src/client/'
           src: ['*.html']
           dest: 'site/client/'
         * expand: true
           cwd: 'src/client/images'
           src: ['*.png']
           dest: 'site/client/images'
         * expand: true
           cwd: 'src/client/'
           src: ['libs/**']
           dest: 'site/client/'
        ]

    watch:
      changes:
        files:
           'src/*.ls'
           'src/test/*.ls'
           'src/client/*.ls'
           'src/client/*.html'
           'src/client/*.less'
           'src/client/images/*.png'
        tasks: ['deadscript' 'copy:all' 'less:all']

    bowercopy:
      options:
        srcPrefix: 'bower_components'
      scripts:
        options:
          destPrefix: 'site/client/libs'
        files:
          'angular/angular.js': 'angular/angular.min.js'
          'angular/angular-route.js': 'angular-route/angular-route.min.js'
          'angular/angular-resource.js': 'angular-resource/angular-resource.min.js'
          'prelude-browser.js': 'prelude-ls/browser/prelude-browser.js'

          'bootstrap/bootstrap.css': 'bootstrap/dist/css/bootstrap.min.css'
          'bootstrap/bootstrap.js': 'bootstrap/dist/js/bootstrap.min.js'
          'jquery.js': 'jquery/dist/jquery.js'

          'angular-bootstrap/ui-bootstrap-tpls.js': 'angular-bootstrap/ui-bootstrap-tpls.min.js'

          # This has been added to avoid the browser error
          #
          'angular/angular.min.js.map': 'angular/angular.min.js.map'
          'angular/angular-route.min.js.map': 'angular-route/angular-route.min.js.map'
          'angular/angular-resource.min.js.map': 'angular-resource/angular-resource.min.js.map'
          'jquery.min.map': 'jquery/dist/jquery.min.map'

          # Copy the bootstrap font files
          #
          'fonts/glyphicons-halflings-regular.eot' : 'bootstrap/fonts/glyphicons-halflings-regular.eot'
          'fonts/glyphicons-halflings-regular.svg' : 'bootstrap/fonts/glyphicons-halflings-regular.svg'
          'fonts/glyphicons-halflings-regular.ttf' : 'bootstrap/fonts/glyphicons-halflings-regular.ttf'
          'fonts/glyphicons-halflings-regular.woff' : 'bootstrap/fonts/glyphicons-halflings-regular.woff'

    less:
      all:
        files: [
          expand: true
          cwd:'src/'
          src: ['**/*.less']
          dest: './site/'
          ext:'.css'
        ]

  grunt.loadNpmTasks 'grunt-contrib-uglify'
  grunt.loadNpmTasks 'grunt-contrib-watch'
  grunt.loadNpmTasks 'grunt-contrib-copy'
  grunt.loadNpmTasks 'grunt-bowercopy'
  grunt.loadNpmTasks 'grunt-deadscript'
  grunt.loadNpmTasks 'grunt-contrib-less'

  grunt.registerTask 'default', ['deadscript' 'less:all' 'copy:all' 'bowercopy' 'watch:changes']
