window.addEventListener('load', () => {
    document.addEventListener('mousedown', handleClickOutside);
});

const toggleUserMenu = () => {
    const userMenu = document.getElementById('user-menu');

    if (userMenu) {
        if (userMenu.hasAttribute('hidden')) {
            userMenu.removeAttribute('hidden');
        } else {
            userMenu.setAttribute('hidden', '');
        }
    }
    
    return true;
}

const toggleBaseballMenu = () => {
    const baseballMenu = document.getElementById('baseball-menu');

    if (baseballMenu) {
        if (baseballMenu.hasAttribute('hidden')) {
            baseballMenu.removeAttribute('hidden');
        } else {
            baseballMenu.setAttribute('hidden', '');
        }
    }

    return true;
}

const handleClickOutside = (e) => {
    const userMenu = document.getElementById('user-menu');
    const baseballMenu = document.getElementById('baseball-menu');
    
    const mobileMenu = document.getElementById('mobile-menu');
    const toggleMobileManu = document.getElementById('toggle-mobile-menu');
    
    if (userMenu && !userMenu.contains(e.target)) {
        userMenu.setAttribute('hidden', '');
    }

    if (baseballMenu && !baseballMenu.contains(e.target)) {
        baseballMenu.setAttribute('hidden', '');
    }

    if (mobileMenu && toggleMobileManu && !mobileMenu.contains(e.target) && !['toggle-mobile-menu', 'toggle-mobile-menu-svg'].includes(e.target.id)) {
        mobileMenu.setAttribute('hidden', '');
    }
}

const toggleMobileMenu = () => {
    const mobileMenu = document.getElementById('mobile-menu');

    if (mobileMenu) {
        if (mobileMenu.hasAttribute('hidden')) {
            mobileMenu.removeAttribute('hidden');
        } else {
            mobileMenu.setAttribute('hidden', '');
        }
    }

    return true;
}

// need this to allow the JS Interop to call it.
window.toggleMobileMenu = toggleMobileMenu;
window.toggleUserMenu = toggleUserMenu;