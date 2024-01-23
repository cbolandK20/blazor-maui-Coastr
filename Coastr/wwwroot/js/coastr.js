//
// App specific JS
//
class CoastR {
    constructor() {

    }

    // methods
    getDimensionFromSelector (cssSelector) {
        let element = document.querySelector(cssSelector);
        if (element == null) {
            return item;
        }


        return [element.clientWidth, element.clientHeight];
    };

    getDimensionFromElement (element) {
        if (element == null) {
            return null;
        }

        console.log(element.clientWidth);
        console.log(element.clientHeight);
        

        return [element.clientWidth, element.clientHeight];
    };
}

// register instance
window.coastr = new CoastR();