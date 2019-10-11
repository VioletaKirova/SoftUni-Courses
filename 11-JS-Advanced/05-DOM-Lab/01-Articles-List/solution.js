function createArticle() {
    let title = document.getElementById('createTitle');
    let content = document.getElementById('createContent');
    let section = document.getElementById('articles');
    
    if (title.value && content.value){
        let article = document.createElement('article');
        let h3 = document.createElement('h3');
        let p = document.createElement('p');
		
        article.appendChild(h3);
        article.appendChild(p);
		
        h3.innerHTML = title.value;
        p.innerHTML = content.value;

        section.appendChild(article);
        
        title.value = '';
        content.value = '';
    }
}