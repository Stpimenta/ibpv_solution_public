window.Observer = {
    observer:null,
    Initialize : function (component,observerTargetId){
        this.observer = new IntersectionObserver(e=>{
            component.invokeMethodAsync('onIntersection');
        });
        let element = document.getElementById(observerTargetId);
        if(element == null) throw new Error("Target not foud");
        this.observer.observer(element);
    }
}