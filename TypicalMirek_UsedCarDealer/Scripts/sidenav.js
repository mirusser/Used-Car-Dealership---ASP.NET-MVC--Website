var jq = jQuery.noConflict();
(function (jq) {
    'use strict';

    var defaults = {};

    var sidenavMove = function (element, options) {
        this.jqel = jq(element);
        this.opt = jq.extend(true, {}, defaults, options);

        this.init(this);
    }

    sidenavMove.prototype = {
        init: function (self) {
            self.initToggle(self);
            self.initDropdown(self);
        },

        initToggle: function (self) {
            jq(document).on('click', function (e) {
                var jqtarget = jq(e.target);

                if (jqtarget.closest(self.jqel.data('sidenav-toggle'))[0]) {
                    self.jqel.toggleClass('show');
                    jq('body').toggleClass('sidenav-no-scroll');

                    self.toggleOverlay();

                } else if (!jqtarget.closest(self.jqel)[0]) {
                    self.jqel.removeClass('show');
                    jq('body').removeClass('sidenav-no-scroll');

                    self.hideOverlay();
                }
            });
        },

        initDropdown: function (self) {
            self.jqel.on('click', '[data-sidenav-dropdown-toggle]', function (e) {
                var jqthis = jq(this);

                jqthis
                  .next('[data-sidenav-dropdown]')
                  .slideToggle('fast');

                jqthis
                  .find('[data-sidenav-dropdown-icon]')
                  .toggleClass('show');

                e.preventDefault();
            });
        },

        toggleOverlay: function () {
            var jqoverlay = jq('[data-sidenav-overlay]');

            if (!jqoverlay[0]) {
                jqoverlay = jq('<div data-sidenav-overlay class="sidenav-overlay"/>');
                jq('body').append(jqoverlay);
            }

            jqoverlay.fadeToggle('fast');
        },

        hideOverlay: function () {
            jq('[data-sidenav-overlay]').fadeOut('fast');
        }
    };

    jq.fn.sidenavMove = function (options) {
        return this.each(function () {
            if (!jq.data(this, 'sidenavMove')) {
                jq.data(this, 'sidenavMove', new sidenavMove(this, options));
            }
        });
    };
})(window.jQuery);
