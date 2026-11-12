# Site de Prunel

*English version: [README.md](README.md).*

Le petit site qui présente Prunel aux visiteurs non techniciens, à l'adresse
<https://prunel.kopol.xyz>. Du HTML et du CSS simples, sans outil ni dépendance.

- `index.html` : page en français (page d'accueil du site).
- `en.html` : page en anglais. Les deux pages ont le même contenu : les modifier ensemble.
- `style.css` : style commun. Gros textes et gros boutons (au moins 72 px de haut), car les
  visiteurs peuvent utiliser un eyetracker ou une souris de tête.
- `contact.js` : affiche l'adresse e-mail de contact seulement après un clic, pour qu'elle
  ne soit jamais écrite en clair dans les pages (protection contre les robots qui collectent
  les adresses pour le spam). L'adresse se règle dans ce fichier.
- `theme.js` : mode clair ou sombre. Par défaut, le site suit le mode du système
  (`prefers-color-scheme`, couleurs dans `style.css`) ; le bouton de thème de la barre du haut
  impose l'autre mode et s'en souvient dans le navigateur. Rechoisir le mode du système fait de
  nouveau suivre le système. Les textes du bouton sont dans les pages HTML.
- `images/` : logo et icône (copies de `docs/images` et de l'icône de l'application, réduites).
- `favicon.ico` : copie de `Resources/Prunel.ico`.

Pour voir une modification, ouvrir `index.html` dans un navigateur.

Mise en ligne : l'hébergement OVH est relié à ce dépôt (branche `main`). Quand une pull request
est fusionnée, un webhook GitHub prévient OVH, qui recopie le dépôt. Le fichier `.htaccess` à la
racine du dépôt fait que le site ne montre que le dossier `website/`.
