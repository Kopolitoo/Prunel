# Tests manuels

*English version: [manual-tests.md](manual-tests.md).*

Prunel ne peut pas être testé automatiquement : ces tests se font à la main, avec un
eyetracker. On fait ceux qui correspondent à ce que change une pull request, et on note dans la
pull request ceux qui ont réussi.

Avant de tester, activer « Journal détaillé » (Paramètres, Système, onglet « Général ») : les
lignes du journal citées plus bas ne sont écrites qu'avec cette option. Journal :
`%LOCALAPPDATA%\Prunel\prunel.log`.

## 1. Mouvement et regard fixe

On fixe un bouton, le cercle se fige (bord blanc, icône d'options) et le
curseur se place sur le bouton ; on regarde ailleurs, il repart. Avec « Clic direct » activé (onglet « Fixation »), en
continuant à fixer le bouton, un anneau se remplit puis un clic gauche est fait. Le journal note chaque passage en regard fixe et
chaque clic direct.

## 2. Choix d'action

On fixe un fichier dans l'Explorateur, on regarde l'icône d'options, l'écran
noir montre la zone agrandie ; on regarde « double clic » : l'écran noir disparaît et le fichier
s'ouvre, sans toucher la souris.

Pause du double clic (issue #59) : Paramètres, onglet « Délais », « Pause du double clic » à
200 ms. Dans le navigateur, ouvrir trois onglets, faire un double clic sur la croix de fermeture
de l'un d'eux : deux onglets se ferment. Remettre 0 ms : un fichier de l'Explorateur s'ouvre
toujours par double clic.

## 3. Menu et pause

On regarde en bas, hors de l'écran : la barre de menu apparaît : seulement des
boutons, sans fond sombre derrière eux, bien espacés (aussi dans la barre de menu du clavier). On regarde
« Pause » : tout s'arrête. On regarde de nouveau en bas : seul « Reprendre » apparaît, et le cercle
reste caché, même en regardant vite ailleurs (issue #49). Après « Reprendre », le cercle revient.
Le tout uniquement au regard. Échap ramène aussi au mode mouvement.

## 4. Loupe

On fixe une petite case à cocher, on regarde l'icône d'options, puis
« Loupe » dans la couronne : la zone apparaît agrandie ×4. On fixe la case sur la photo : le
choix d'action s'ouvre, la croix est sur la case ; « clic gauche » la coche. Pas besoin de
détourner le regard puis d'y revenir : si le regard est déjà sur la case quand la photo apparaît,
le choix d'action s'ouvre après le délai habituel (issue #91).
« Délai de la loupe » (onglet « Loupe, glisser ») : à 0.3 s, le choix d'action s'ouvre plus vite
depuis la loupe, alors que le regard fixe du mode mouvement garde le « Délai de fixation ». Un
ancien fichier de réglages démarre avec un délai de la loupe égal à son délai de fixation. Avec « Loupe avant l'action » activée (onglet « Loupe, glisser »), la loupe s'ouvre directement après l'icône
d'options.

## 5. Modificateurs et glisser-déposer

Dans l'Explorateur, on fixe un fichier, on ouvre le choix d'action, on
regarde « Ctrl » (bord vert) puis « clic gauche » ; on recommence sur un autre fichier : les deux
sont sélectionnés. Puis on fixe un fichier, on choisit « glisser-déposer gauche » (quatre flèches,
pastille G), on regarde le dossier d'arrivée (la ligne en pointillés suit), on le fixe, on affine
dans la loupe : le fichier est déplacé. Le bouton « retour » à droite annule. Arrivée proche du
départ (un fichier voisin) : dans la loupe, une petite croix (plus petite que celle du choix
d'action) marque le point de départ ; un regard fixe dessus est une arrivée normale. Arrivée
lointaine : pas de croix.

## 6. Paramètres

Menu, « Paramètres » : l'écran noir s'ouvre sur l'onglet Regard. On garde
le regard sur « + » du lissage : la valeur monte d'un pas toutes les 0,4 s. On regarde l'onglet
Fixation, puis l'interrupteur du clic direct : il passe au bleu, rond à droite, « Oui ». « Défaut », puis « Oui » :
les valeurs de l'onglet reviennent. L'aidant clique sur une valeur, tape 0,5 puis Entrée.
« Retour » ramène au mode mouvement. Lancer Prunel une deuxième fois ne fait rien (voir le
journal).

## 7. Défilement

On ouvre une longue page web, on fixe le texte, on ouvre le choix d'action
puis « Défilement » (à gauche, en haut). Le cercle blanc reste en place. On regarde dans le
cercle : rien ne bouge. On regarde un peu sous le cercle : la page descend doucement ; plus bas :
plus vite. Au-dessus : elle remonte. « Retour » au bord droit ramène au mode mouvement.
Depuis le 02/11/2026 : à vitesse lente, la page doit glisser sans petits sauts, et démarrer
ou s'arrêter en douceur ; sans avoir cliqué dans la page avant, elle doit défiler quand même
(le journal note « fenêtre … rendue active » et l'état du réglage Windows de la molette).
On rouvre le défilement et on regarde directement sous le cercle, sans passer dedans : la page
doit commencer à descendre en moins d'une demi-seconde, sans bouger le regard. Chaque départ doit
être doux : lent au début, puis plus rapide en une seconde et demie environ ; juste au bord du
cercle, très lent. On regarde hors de l'écran à droite pendant une seconde : retour au mode
mouvement. On regarde hors de l'écran en haut, en bas et à gauche : ça défile toujours à vitesse
maximale dans ce sens. On rouvre le défilement et on dit « Échap » à Dragon : retour au mode
mouvement.
Avec un menu d'un logiciel ouvert sous le cercle, Échap en mode défilement ne doit pas fermer
ce menu (Prunel garde la touche). Pareil avec le clavier au regard ouvert : Échap ferme
seulement le clavier.

## 8. Configuration des icônes

Menu, « Paramètres », onglet « Choix d'action », « Configurer les icônes ». On
regarde le « − » du clic gauche (en haut à gauche de la couronne) puis celui du clic droit : les
deux emplacements deviennent vides (« + »). On regarde le premier : la liste propose toutes les
actions de la couronne ; on choisit « Clic droit ». On fait de même avec l'autre emplacement et « Clic
gauche » : les deux actions ont échangé leur place. « Retour », puis dans le choix d'action, les
deux icônes sont à leur nouvelle place. Retirer « Couper » laisse un emplacement grisé en haut
du choix d'action. « Défaut » dans l'onglet « Choix d'action » remet tout comme avant.

## 9. Tailles d'écran

Écran en 1920 × 1080 à 100 %. Au premier lancement, le journal note
« mise à jour en version 7 » et l'écran détecté ; le cercle, les icônes et la barre de menu ont
à l'œil la même taille qu'avant en 4K. Onglet « Affichage » : « Écran détecté » donne la
résolution, l'échelle et la taille du texte ; « Taille de l'interface » à 150 % agrandit le
cercle, les icônes et le menu. Pendant que Prunel tourne, on change la résolution, puis la
mise à l'échelle (125 %), puis la taille du texte de Windows : à chaque fois, le journal note
« changement détecté » et les tailles s'adaptent (un choix d'action ou une loupe ouverts se
ferment, retour au mode mouvement ; la pause, le jeu et les paramètres restent ouverts).

## 10. Clavier du regard

Dans le Bloc-notes, on ouvre le menu, « Clavier » : le clavier apparaît en
bas. On regarde des touches : elles s'éclaircissent, flashent et le texte s'écrit (« é » depuis
la page « À,È,Ê »). On regarde au-dessus du clavier : le cercle revient et le regard fixe marche.
On tape un moment sur les touches en haut à droite : le bouton Fermer, bien séparé du clavier,
ne se déclenche jamais par erreur (de même sous le clavier quand il est en haut).
On regarde sous l'écran : la barre du clavier s'ouvre et le clavier remonte au-dessus d'elle ;
« Haut / bas » le met en haut (il s'y rouvre la fois suivante), « Taille » affiche « Perso », puis « Petit » (60 %), « Grand » (100 %) et à nouveau « Perso » (retenu
à la réouverture) ; dans les Paramètres, « Taille du clavier » avance de 5 % (30 à 100 %) : on règle
80 %, la barre du clavier affiche « Perso » et le clavier s'ouvre à 80 %,
« Pause » le cache jusqu'à la reprise. Dans la configuration des icônes, on place « Clavier » sur la couronne : dans le choix
d'action, ce bouton ouvre le clavier. Dans le Bloc-notes avec plusieurs lignes de texte, on fixe
le milieu d'une ligne (Bloc-notes pas actif, ou une autre fenêtre devant), on choisit « Clavier » :
le curseur de texte va à cet endroit et les touches tapées s'y écrivent. Clavier ouvert, on fixe un
autre endroit du texte et on choisit de nouveau « Clavier » : le clavier reste ouvert, le curseur
de texte va au nouvel endroit et les touches tapées s'y écrivent (issue #133).

## 11. Prédiction de mots

Dans le Bloc-notes, on ouvre le clavier et on tape « bo » : les cases
proposent « bon », « bonne »… ; on regarde « bonjour » (après « bonj ») : « bonjour » et une espace
s'écrivent. « ete » propose « été ». « pr » propose des mots courts (« pris », « près »…) avant « prendre ». On tape un mot inventé (« zorglub ») : la 1re case montre
« + zorglub » en ambre ; on la regarde : une espace s'écrit, et en tapant « zo » le mot est
proposé. On tape « 2026 » : aucune case « + » n'apparaît ; on tape « mp3x » : « + mp3x » apparaît. On écrit deux fois « je suis » (en tapant « suis » en entier puis une espace) : après
« je » et une espace, la 1re case propose « suis ». Après avoir fermé Prunel, `%APPDATA%\Prunel\personal-dictionary.json` contient le mot.

Mots courts d'abord (issue #122) : dans les paramètres, catégorie « Interface », onglet
« Prédiction », « Mots courts d'abord » vaut 1.3 (aussi après une mise à jour depuis une
ancienne version). On le met à 2.0 et on tape « pr » : seulement des mots courts ; on le met à
1.0 et on tape « pr » : les mots les plus courants, longs compris (« prendre »…). « − » s'arrête
à 1.0, « + » à 2.0. « Défaut » remet 1.3.

## 12. Options du clavier

Clavier ouvert, on regarde sous l'écran : la barre du clavier montre aussi
« Zone de saisie » et « Disposition du clavier ». « Zone de saisie » : le bord devient vert, une
bande apparaît au-dessus des touches ; on tape « bonjour à tous » : la bande le montre ; une
flèche la vide. « Disposition du clavier » : la liste montre « Français AZERTY » avec un bord vert ; « Retour au
clavier » ramène au clavier. Paramètres, onglet Prédiction, « Mes mots » : « zorglub » (ajouté à
l'étape 13) est dans la liste ; on le regarde : il disparaît ; « Retour aux paramètres » ramène à
l'onglet Prédiction. En tapant « zo », il n'est plus proposé.
« Transparence » (montre « 0 % ») : on la regarde : « 25 % », les fonds du clavier laissent
voir la fenêtre derrière ; encore : « 50 % », « 75 % », puis « 0 % » (opaque comme avant). À 75 %,
les lettres, l'éclair vert et le survol restent bien visibles. On ferme et rouvre Prunel : la
valeur est gardée.

## 13. Clavier anglais

Clavier ouvert, « Disposition du clavier » : la liste montre
« English QWERTY » et « Français AZERTY » ; on choisit « English QWERTY » : lettres en QWERTY, et
avec l'interface en français, « bonj » propose toujours « bonjour ». Paramètres, Général,
« Langue » → English ; retour au clavier : « th » propose « the », « that », « this » (ou proches),
« don » et « don' » proposent « don't ».

## 14. Profils de réglages

Paramètres, Système, Profils, « Enregistrer les réglages actuels » : le
clavier du regard apparaît avec la page Nom ; écrire « Soir », regarder « Enregistrer » : le
message donne le nom du profil, et le fichier apparaît dans `Documents\Prunel\Profiles`. On
change le rayon du cercle (Affichage). Profils, « Charger un profil » : la liste montre le profil ;
on le regarde : « Charger le profil … ? » ; « Non » ne change rien ; « Oui » remet l'ancien rayon et
crée « Sauvegarde automatique ». Charger « Sauvegarde automatique » remet le rayon modifié.

## 15. Retour sonore

Paramètres, « Interface », onglet « Sons » : les deux interrupteurs sont sur non ; rien ne
fait de son. Activer « Son des touches » : ouvrir le clavier et taper : un petit « tic » aigu à
chaque touche (aussi avec la répétition), mais aucun son pour le menu ni le choix d'action. Le
désactiver et activer « Son des boutons » : les touches sont muettes ; l'icône d'options, le choix
d'action, les boutons du menu et ceux des paramètres font un petit son de deux notes. Tout
désactiver : de nouveau le silence. Relancer Prunel : les choix sont gardés.

## 16. Survol des menus (issue #97)

Faire un clic droit sur le bureau, puis dans l'Explorateur, pour ouvrir un menu contextuel. Fixer
un élément du menu : quand le cercle se fige et que le curseur le rejoint, l'élément est mis en
surbrillance, comme avec une vraie souris ; sur un élément avec une petite flèche, le sous-menu
s'ouvre. Même test avec « Suivi souris » activé (la surbrillance suit le regard), et en mode jeu
« direct ». Le curseur reste exactement sur le cercle (pas de décalage d'un pixel).

## 17. Nouveau mot après un clic (issue #96)

Ouvrir une page web avec un formulaire de plusieurs champs (ou deux zones de texte). Ouvrir le
clavier, cliquer dans le premier champ et taper quelques lettres, sans espace. Avec le regard,
cliquer dans le deuxième champ : les cases de suggestion se vident aussitôt. Taper une lettre :
les suggestions partent de cette seule lettre, et non du mot du premier champ. Même test avec un
clic dit à la reconnaissance vocale, et avec une vraie souris. Écrire plusieurs mots dans le
même champ sans cliquer marche toujours comme avant (mots suivants proposés après une espace).
Retaper quelques lettres, puis appuyer sur une flèche (ou Suppr) d'un vrai clavier, ou la dire
à Dragon : les cases de suggestion se vident aussi. Appuyer seulement sur Maj ou Ctrl ne change
rien.

## 18. Stabilité du regard dans la fenêtre Diagnostic (issue #86)

Ouvrir les paramètres, onglet « Outils », « Diagnostic ». Sous la miniature de l'écran, trois
lignes « Haut », « Milieu » et « Bas » montrent des nombres qui augmentent quand on regarde
l'écran. Fixer un point près du bord haut une vingtaine de secondes, puis au milieu, puis près
du bord bas : le nombre de « mesures » augmente dans la bonne ligne. Fermer les yeux une
seconde : les « pertes » augmentent dans la bande regardée. « Remettre les mesures à zéro »
remet tout à 0. Fermer puis rouvrir la fenêtre : tout repart de 0. Aucun nouveau fichier
n'apparaît dans `%LOCALAPPDATA%\Prunel\` et le journal ne contient aucune position du regard.

## 19. Pause automatique

Uniquement au regard et à la voix : pas besoin de toucher la souris ni le câble USB.

1. Paramètres, catégorie « Regard », onglet « Pause » : « Pause automatique » est activée,
   « Délai avant la pause » vaut 10 s. « − » et « + » le changent d'une seconde à la fois
   (issue #160). Régler le délai sur 5 s, puis revenir au mode mouvement.
2. Fermer les yeux (ou tourner la tête loin de l'eyetracker) environ 6 secondes, puis regarder
   de nouveau l'écran : le cercle a disparu et un bouton rond « Reprendre » est au centre de
   l'écran. Ailleurs sur l'écran, rien n'est cliqué et le curseur ne bouge pas.
3. Regarder « Reprendre » : son anneau se remplit, puis le cercle revient (mode mouvement).
4. Fermer les yeux seulement 3 secondes : pas de pause.
5. Regarder sous l'écran pendant 6 secondes : le menu s'ouvre, pas de pause automatique. Fermer
   le menu.
6. Ouvrir le clavier du regard, fermer les yeux 6 secondes : pause automatique, le clavier est
   caché ; après « Reprendre », le clavier revient.
7. De nouveau en pause automatique, regarder sous l'écran : le menu ne montre que « Reprendre »
   et le bouton du centre disparaît ; laisser le menu se fermer : le bouton du centre revient.
   Échap (dit à Dragon) ramène aussi au mode mouvement.
8. Ouvrir les paramètres et fermer les yeux 6 secondes : pas de pause (les paramètres restent
   ouverts). Pareil dans la loupe et le choix d'action.
9. Désactiver « Pause automatique » : fermer les yeux ne la déclenche plus. Remettre le délai à
   10 s (ou « Défaut »). Le journal indique « Automatic pause: gaze lost for 5 s » et ne contient
   aucune position du regard.

## 20. Boutons « Retour » au bord droit (issue #53)

Uniquement au regard. Pour chaque écran ci-dessous, regarder le bord droit de l'écran à la
hauteur de « Retour », entre le bouton et le bord, puis un peu au-delà du bord (hors de
l'écran) : le bouton s'éclaire, son anneau se remplit, et il revient en arrière comme d'habitude.

1. Choix d'action : « Retour » ramène au mode mouvement.
2. Loupe (depuis le choix d'action) : « Retour » revient en arrière.
3. Glisser-déposer, choix du point d'arrivée : « Retour » annule. Un point d'arrivée ailleurs
   marche toujours.
4. Défilement : « Retour » termine le défilement. Regarder hors de l'écran à droite le termine
   toujours au bout d'une seconde.
5. Paramètres : « Retour » (milieu de la colonne de droite) ramène au mode mouvement.
   « Défaut », au-dessus, ne réagit pas à un regard hors de l'écran.
6. Paramètres, « Configurer les icônes » : « Retour » ramène aux paramètres. Listes
   (« Disposition du clavier », « Mes mots », profils) : « Retour » revient en arrière.
7. Clavier du regard : fixer juste à côté de la croix « Fermer » (à sa gauche, en dessous, ou au
   bord droit de l'écran) ferme le clavier. Taper sur la rangée de touches du haut ne le ferme
   jamais.
8. Regarder hors de l'écran loin à droite (une largeur de main ou plus), ou bien au-dessus ou
   en dessous de « Retour » : rien ne se passe. En mode mouvement, le menu s'ouvre toujours en
   regardant sous l'écran.

## 21. Touches de page qui reviennent en arrière (issue #106)

Uniquement au regard, clavier du regard ouvert sur la page des lettres.

1. Regarder « 123.! » et continuer à regarder : la page des chiffres apparaît (« ABC » au même
   endroit), puis après deux fois le délai des touches (plus lent que pour écrire) la page des lettres revient, puis les chiffres…
   Détourner le regard : ça s'arrête.
2. Pareil avec « [(/ » : symboles, puis retour aux lettres (pas aux chiffres, bien que
   « 123.! » soit à cet endroit sur la page des symboles).
3. Pareil avec « À,È,Ê » (accents ↔ lettres) et, depuis la page des chiffres, « F1..F12 »
   (touches F ↔ chiffres).
4. Regarder « 123.! », puis détourner le regard et revenir sur « ABC » : on va à la page des
   lettres comme d'habitude.
5. Marche pareil avec « Répétition » désactivée (Paramètres, onglet du clavier).

## 22. Fondu du fond noir (issue #116)

Uniquement au regard.

1. Fixer un point en mode mouvement : l'écran noir du choix d'action arrive en douceur
   (environ 0,2 s) au lieu d'un coup. Les boutons marchent tout de suite.
2. « Retour » : l'écran noir s'efface en fondu (environ 0,15 s), l'écran réel revient sans
   flash. Pareil après un clic gauche : le clic se fait comme d'habitude (un lien s'ouvre, un
   champ prend le focus).
3. Loupe (depuis le choix d'action ou directement) : son écran noir arrive et part aussi en
   fondu. La photo du choix d'action et de la loupe ne montre jamais l'écran noir lui-même.
4. Défilement et glisser-déposer depuis le choix d'action : l'écran noir s'efface pendant que
   le mode démarre ; défiler et déposer marchent comme avant.
5. « Configurer les icônes » (paramètres, onglet « Choix d'action ») et les listes du clavier : ils arrivent en fondu ;
   changer de page dans une liste ne refait pas de fondu.

## 23. Onglet « À propos » (issue #92)

1. Paramètres, catégorie « Système » : le dernier onglet est « À propos ». Il montre « Prunel »,
   « Version 0.5.0 » (le numéro de la version installée, sans le « + » et les lettres qui
   peuvent suivre), les deux boutons « Site web » et « Guide d'utilisation », et à droite
   l'image de l'auteur avec « Créé par Kopolito » et « avec l'aide de Claude, une IA d'Anthropic » dessous. Il n'y a pas de bouton « Défaut ».
   Regarder l'image ne fait rien.
2. Regarder « Site web » : le navigateur par défaut ouvre le site de Prunel (la page en
   français quand l'interface est en français, en anglais sinon) et Prunel revient au mode
   mouvement.
3. Rouvrir les paramètres, onglet « À propos », « Guide d'utilisation » : le navigateur ouvre
   le guide d'utilisation sur GitHub, dans la langue de l'interface.
4. Changer de langue (onglet Général) et revenir : les textes et les adresses suivent la langue.

## 24. Couleurs du cercle (étape color-themes)

1. Paramètres, catégorie « Interface » : un onglet « Couleurs » vient juste après
   « Affichage », avec trois lignes : « Couleur du cercle » (Gris), « Épaisseur du cercle »
   (100 %), « Contraste renforcé » (non). Avec ces valeurs, le cercle est exactement comme avant.
   Dessous, un aperçu : un panneau sombre et un panneau clair, chacun avec un cercle
   « Mouvement » et un cercle « Regard fixe » avec un anneau vert aux deux tiers. L'aperçu a la
   vraie taille du cercle et n'est pas une cible du regard.
2. Regarder « + » sur « Couleur du cercle » : un regard = une couleur de plus (Blanc, Jaune,
   Vert, Bleu clair, Bleu foncé, Violet, Rose, puis Gris à nouveau) ; garder le regard sur « + » ne fait pas défiler
   la liste. « − » revient en arrière. Cliquer sur la valeur à la souris n'ouvre pas de zone de
   saisie. L'aperçu change de couleur tout de suite, et suit aussi l'épaisseur et le contraste
   (étapes 4 et 5).
3. Choisir Jaune, revenir au mode mouvement : le cercle est jaune ; en regard fixe il est jaune
   aussi, plus visible. En mode défilement il est jaune et plus pâle.
4. « Épaisseur du cercle » 200 % : les traits sont deux fois plus épais ; 50 % : plus fins. La
   valeur s'arrête à 50 et 400 %.
5. « Contraste renforcé » oui : le cercle est opaque avec un bord noir des deux côtés, sur une
   page blanche comme sur une page sombre ; l'anneau de progression du clic direct est plus
   épais.
6. « Défaut » : les trois lignes reviennent à Gris, 100 %, non. Redémarrer Prunel : les choix
   sont gardés. Un ancien fichier de réglages (version 18) s'ouvre avec le cercle habituel.

## 25. Mode nuit (étape color-themes)

1. Paramètres, onglet « Couleurs » : une quatrième ligne « Mode nuit » (non). Les quatre lignes
   et l'aperçu tiennent sur la page sans se chevaucher.
2. L'activer : tout de suite, les textes des paramètres passent en gris clair au lieu du blanc,
   les interrupteurs en bleu plus sombre, les barres de progression en vert plus sombre. La
   couleur du cercle ne change pas.
3. Revenir au mode mouvement : l'icône d'options (regard fixe) est grise avec un flash vert plus
   sombre ; l'anneau de progression du clic direct est vert plus sombre.
4. Ouvrir la barre de menu, le choix d'action, la loupe, le clavier (avec la zone de saisie) et
   la liste des claviers : symboles et textes en gris clair, flashs et anneaux en vert plus
   sombre, le cercle du regard des modes plein écran en vert plus sombre, la case « + monmot » en
   ambre plus sombre.
5. Le désactiver : tout revient aux couleurs de jour (à la prochaine ouverture de chaque écran).
   Redémarrer Prunel : le choix est gardé. « Défaut » de l'onglet le désactive.

## 26. Rayon de la capture séparé (issue #123)

1. Paramètres, onglet « Affichage » : une deuxième ligne « Rayon de la capture » (même valeur
   que « Rayon du cercle », 8.8 % sur une nouvelle installation). Les cinq lignes sont un peu plus
   serrées, et le texte « Écran détecté » en dessous est entièrement visible au-dessus du bas de
   la page.
2. « Rayon du cercle » 3 %, « Rayon de la capture » 6 %. Revenir au mode mouvement : le cercle
   qui suit le regard est petit. Fixer un point : le cercle du regard fixe a la même petite
   taille.
3. Choix d'action et loupe : la photo a la taille d'un cercle de 6 % ; les icônes de la couronne
   ne chevauchent pas la photo.
4. « Rayon de la capture » : « − » s'arrête à 4 %.
5. Un ancien fichier de réglages (version 22) s'ouvre avec « Rayon de la capture » = son
   « Rayon du cercle » (au moins 4 %) : rien ne change. « Défaut » de l'onglet remet les deux à
   8.8 %.

## 27. Photo ronde (issue #143)

1. Au milieu de l'écran : ouvrir le choix d'action. La photo est un rond avec un fin anneau gris,
   la croix est en son centre ; les icônes de la couronne ne la recouvrent pas.
2. Loupe depuis là : l'image est ronde aussi. Fixer la cible dedans ouvre le choix d'action sur
   le bon point ; fixer les coins noirs autour du rond ne fait rien.
3. Près du bord gauche de l'écran (une icône du bureau), puis dans le coin en bas à droite
   (l'horloge de la barre des tâches) : le rond est coupé droit du côté du bord de l'écran, la
   croix est toujours au centre, et la loupe atteint toujours la cible.
4. Paramètres, onglet « Choix d'action », « Configurer les icônes » : l'aperçu gris est rond, son texte
   tient dedans.

## 28. Garder un bouton de la souris enfoncé (issue #126)

1. Configuration des icônes : la liste de la couronne montre « Gauche maintenu » et « Droit
   maintenu » (cadenas, pastilles G et D). Placer « Droit maintenu » sur un emplacement.
2. Dans Paint, fixer la toile, choisir « Droit maintenu » : le choix d'action se ferme, un bouton
   carré « Relâcher le bouton » apparaît au bord droit. Bouger le regard : un trait se dessine
   (couleur du bouton droit) là où va le curseur. Petit tremblement du regard au repos : le curseur
   ne bouge pas.
3. Le bouton est deux fois plus gros que les autres icônes. Un bref regard sur « Relâcher le
   bouton » (pas d'anneau à attendre) : le trait s'arrête, retour au mode mouvement (le cercle revient).
4. Pareil avec « Gauche maintenu », puis appuyer sur Échap (ou dire « Échap » à Dragon) pendant le
   dessin : le bouton est relâché, retour au mode mouvement.
5. Pendant le dessin, fermer les yeux environ 2 s : le bouton est relâché. Un clignement normal
   ne le relâche pas.
6. Avec Ctrl allumé dans le choix d'action, « Gauche maintenu » : Ctrl est enfoncé aussi, et
   relâché avec le bouton.
7. Dans Back to Bed : « Droit maintenu » déplace le personnage vers le regard.

## 29. Sonnette d'appel sur l'ordinateur (étape call-bell)

1. Ouvrir le menu depuis le mode mouvement : « Raccourcis », puis le bouton « Appeler » (sonnette)
   de la colonne. Le regarder : un « ding-dong » sonne sur l'ordinateur pendant environ 6 s, « Appel
   envoyé » s'affiche au-dessus de la barre, le menu reste ouvert.
2. Regarder de nouveau « Appeler » dans les 5 s : rien ne sonne, « Appel déjà envoyé ». Après
   5 s, ça sonne de nouveau.
3. Paramètres, catégorie « Actions », onglet « Sonnette » : changer la durée (2 s, puis 15 s) et
   le volume (30 %, puis 100 %) : l'appel suivant les suit. « Défaut » : oui, 6 s, 80 %.
4. Désactiver « Sonnette de l'ordinateur », puis « Appeler » : rien ne sonne, « Aucune sonnette
   activée (paramètres, onglet Sonnette) ».
5. Avec « Son des boutons » activé (onglet Sons) : pendant la sonnerie, regarder d'autres boutons
   du menu ne coupe pas la sonnette.
6. Ouvrir le clavier du regard, puis sa barre (regarder sous l'écran) : un bouton « Appeler » y
   est aussi, et sonne.
7. Depuis la pause : la barre ne montre que « Reprendre » (pas de sonnette). Depuis le mode jeu :
   « Appeler » est dans la colonne Raccourcis.
8. Avec une enceinte Bluetooth comme sortie de Windows : la sonnette sonne dans l'enceinte.
9. Volume de Windows à 20 %, puis « Appeler » : le volume monte à 80 % pendant la sonnerie, puis
   revient à 20 %. Pareil avec le son coupé : réactivé pendant la sonnerie, recoupé après. Volume
   de Windows à 90 % : inchangé. « Volume de Windows pendant la sonnerie » à 0 : le volume n'est
   jamais touché.
10. Quitter Prunel pendant la sonnerie : le volume de Windows revient.
11. Onglet « Sonnette » (issue #162) : un petit bouton « Tester » est sous les quatre réglages. Le
    regarder : la sonnette sonne avec la durée et les volumes actuels, « La sonnette de
    l'ordinateur sonne » s'affiche sous le bouton. Changer la durée ou le volume, puis « Tester » de
    nouveau : le son suit. Désactiver « Sonnette de l'ordinateur » : « Tester » sonne quand même.
    Garder le regard sur « Tester » ne sonne qu'une fois.

## 30. Sonnette d'appel sur une enceinte Alexa (étape call-bell, partie 2)

Il faut l'installation de Voice Monkey du guide (skill, déclencheur de routine, routine Alexa,
jeton).

1. Paramètres, catégorie « Actions », onglet « Alexa » : « Jeton : aucun », « Appareil :
   aucun ». « Tester » : message « collez d'abord le jeton et l'appareil ».
2. Copier un mauvais texte avec une espace, « Coller le jeton » : « Le presse-papiers ne
   contient pas de jeton… ».
3. Copier le jeton, « Coller le jeton » : « Jeton : enregistré (chiffré) ». Ouvrir
   `settings.json` : le jeton n'est pas lisible en clair. `prunel.log` ne le contient pas.
4. Copier l'identifiant du déclencheur, « Coller l'appareil » : l'identifiant s'affiche.
   « Tester » : « Test en cours… », puis l'Echo sonne et « Voice Monkey a lancé la routine ».
   Noter le nombre de secondes.
5. Activer « Sonnette Alexa ». Menu, « Appeler » : « Appel en cours… », puis « Appel envoyé » ;
   l'ordinateur et l'Echo sonnent.
6. Coller un faux jeton, « Tester » : « le jeton est refusé ». Recoller le bon.
7. Couper Internet (ou le Wi-Fi), « Appeler » avec la sonnette de l'ordinateur DÉSACTIVÉE : après
   10 s au plus, « La sonnette a échoué : l'ordinateur a sonné à la place », et l'ordinateur
   sonne. Avec la sonnette de l'ordinateur ACTIVÉE : « Appel envoyé, mais une sonnette a échoué ».
8. Enregistrer un profil, changer le jeton, charger le profil : le jeton actuel reste.

## 31. Quitter depuis l'onglet « Général » des paramètres

1. Paramètres, catégorie « Système », onglet « Général » : tout en bas à droite de l'écran,
   le bouton « Quitter Prunel » (symbole marche/arrêt). Rien ne se
   chevauche (l'explication au-dessus reste lisible).
2. Regarder « Quitter Prunel » : la question « Quitter Prunel ? » apparaît avec « Oui » et
   « Non » bien plus haut. Garder le regard là où était le bouton ne répond pas à la question.
3. Regarder « Non » : l'onglet « Général » revient, Prunel continue.
4. Recommencer, puis regarder « Défaut » pendant la question : la question « Remettre les
   valeurs par défaut… » la remplace. Regarder « Non ».
5. Recommencer et regarder « Oui » : Prunel se ferme (plus de cercle, aucun bouton de la souris
   ni touche restés enfoncés) ; le journal dit « Settings: Prunel exit requested ».
6. En anglais : le bouton s'appelle « Quit Prunel ».

## 32. Anti-tremblement du jeu (issue #124)

1. Avant d'installer : noter la valeur « Anti-tremblement » (Paramètres, onglet « Regard »).
   Installer la nouvelle version : l'onglet « Jeu » montre « Anti-tremblement du jeu » (sous
   « Lissage du jeu ») avec la MÊME valeur ; le journal dit « Settings: updated to version 27
   (game anti-jitter) ». Rien n'a changé en mode jeu ni en mode mouvement.
2. Mettre « Anti-tremblement du jeu » à 0 (pas de 0,05 %) : en mode jeu, le curseur suit même
   les tout petits mouvements du regard ; de retour en mode mouvement, le curseur se comporte
   comme avant (la valeur de l'onglet « Regard » n'a pas changé).
3. Mettre « Anti-tremblement du jeu » à 2 % : en mode jeu, le curseur reste immobile pour les
   petits mouvements du regard. « Droit maintenu » (s'il est placé sur la couronne) se
   comporte de la même façon.
4. Changer « Anti-tremblement » de l'onglet « Regard » : la valeur du jeu ne change pas.
5. « Défaut » dans l'onglet « Jeu » : « Anti-tremblement du jeu » revient à 0.40 %.
6. En anglais : « Game anti-jitter ».
7. « Gauche maintenu » et « Droit maintenu » ont un fond violet léger (plus sombre en mode
   nuit), dans le choix d'action et dans l'écran de configuration des icônes ; quand on les
   regarde, le violet s'éclaircit. Les autres boutons gardent leur fond sombre habituel.

## 33. Animation d'ouverture de la loupe et du choix d'action (issue #154)

1. Installer la nouvelle version. Paramètres, catégorie « Actions » : l'ancien onglet « Icônes »
   s'appelle maintenant « Choix d'action » : le bouton « Configurer les icônes », et dessous
   « Animation d'ouverture » (activée).
2. Regard fixe → choix d'action (loupe avant l'action désactivée) : la photo ronde part
   exactement de l'endroit fixé, à sa vraie taille, et grandit jusqu'au centre de l'écran
   (environ un quart de seconde) ; puis les icônes, la croix et le cercle du regard
   apparaissent en fondu. Regarder une icône pendant l'animation ne fait rien ; une fois
   affichées, les icônes marchent comme avant.
   La photo va vite au début et ralentit à la fin. Sur un écran plus rapide que 60 Hz, le
   mouvement peut montrer plus d'images par seconde (jusqu'à 144).
3. Pareil avec « Loupe avant l'action » activée : la photo de la loupe grandit depuis
   l'endroit fixé, puis l'icône « retour » apparaît ; la fixation sur la photo ne compte
   qu'une fois la photo en place. Ensuite le choix d'action s'ouvre SANS repasser par le vrai
   écran : l'écran noir reste, et sa photo part du point fixé sur la loupe (à la taille de la
   loupe) puis rétrécit jusqu'au centre. Pas de flash.
3b. « Retour » de la loupe (ouverte depuis la couronne du choix d'action) et « Loupe » du choix
   d'action : même passage en douceur entre les deux écrans, dans les deux sens.
4. Près d'un bord et dans un coin de l'écran : la photo part toujours de l'endroit fixé (coupée
   droit par le bord) et finit au centre.
5. Désactiver « Animation d'ouverture » : les écrans s'ouvrent d'un coup, comme avant (fondu du
   noir seulement).
6. « Défaut » dans l'onglet « Choix d'action » la réactive (et remet la disposition des icônes). En anglais : "Action choice" tab,
   "Opening animation".

## 34. Transparence du fond de la loupe et du choix d'action (issue #155)

1. Installer la nouvelle version (paramètres d'avant la version 29). Paramètres, onglet « Choix
   d'action » : « Transparence du fond » (100 %) sous « Animation d'ouverture ». La loupe et le
   choix d'action n'ont plus de fond noir. La mettre à 0 % : entièrement noir, comme avant.
2. La mettre à 50 % : le vrai écran se voit, assombri, autour de la photo du choix d'action et
   de la loupe. La photo, les icônes et le cercle du regard restent bien visibles.
3. La mettre à 100 % : plus de fond noir du tout ; seules la photo et les icônes sont dessinées
   par-dessus le vrai écran. Les icônes, la fixation de la loupe et « retour » marchent comme
   avant.
4. L'écran de configuration des icônes et les listes du clavier restent entièrement noirs.
5. « Défaut » dans l'onglet « Choix d'action » la remet à 100 %. En anglais : "Background
   transparency".

## 35. Relâcher le bouton maintenu par un regard fixe (issue #158)

1. Installer la nouvelle version (paramètres d'avant la version 30). Paramètres, catégorie
   « Regard », onglet « Pause » : « Relâcher le bouton maintenu » (1,5 s) sous « Délai avant la
   pause ».
2. Dans Paint, « Gauche maintenu » (voir le test 28), tracer un trait, puis garder le regard
   fixe sur un endroit : au bout d'environ 1,5 s, le trait s'arrête juste là, retour au mode
   mouvement. Pendant ce temps, un arc vert se remplit autour de l'endroit (il apparaît après
   environ 0,3 s, puis se ferme quand le bouton est relâché). Aucun clic ne suit aussitôt (le regard doit d'abord quitter l'endroit).
3. Glisser un fichier dans l'Explorateur avec « Gauche maintenu » : regarder un dossier et garder
   le regard fixe : le fichier est déposé dans ce dossier.
4. Un regard qui bouge lentement (suivre une ligne) ne relâche pas le bouton ; un arrêt court
   (moins de 1,5 s) non plus.
5. Régler sur 0 : un regard fixe ne relâche plus le bouton ; « Relâcher », Échap et le regard
   perdu le relâchent toujours. « Défaut » remet 1,5 s. En anglais : "Release the held button".

## 36. Durée de l'animation d'ouverture et interrupteur plus petit (issue #161)

1. Installer la nouvelle version (paramètres d'avant la version 31). Paramètres, onglet « Choix
   d'action » : « Animation d'ouverture », puis « Durée de l'animation » (0,4 s), puis
   « Transparence du fond ». Les trois lignes tiennent au-dessus du bas de la page.
2. L'interrupteur « Animation d'ouverture » est plus petit qu'avant (environ la taille du bouton
   « Configurer les icônes »), comme tous les interrupteurs des paramètres (Pause, Couleurs,
   Sons, Général…) ; en regarder un l'active et le désactive toujours, et garder le regard dessus
   ne le bascule qu'une fois.
3. Mettre « Durée de l'animation » à 2 s : la photo de la loupe et du choix d'action grandit
   lentement, puis les icônes apparaissent ; elles ne marchent qu'une fois affichées. La mettre à
   0,2 s : très rapide.
4. « Défaut » dans l'onglet « Choix d'action » remet 0,4 s (même vitesse qu'avant). En anglais :
   "Animation duration".

## 37. Mes mots : corriger, ajouter à la main, bouton dans Prédiction (issue #163)

1. Paramètres, onglet « Général » : plus de bouton « Mes mots », le bouton de langue est à
   gauche. Onglet « Prédiction » : un petit bouton « Mes mots » sous « Mots courts d'abord ». Le
   regarder.
2. La liste montre deux boutons en bas : « Ajouter un mot » et « Corriger des mots ». Regarder
   « Ajouter un mot » : les paramètres s'ouvrent sur l'onglet Prédiction, titre « Mot à ajouter à
   Mes mots », case vide, le clavier du regard dessous. Taper « zorglub », regarder
   « Enregistrer » : retour à la liste, « Mot ajouté. » en vert, « zorglub » y est.
3. De nouveau « Ajouter un mot » : taper « zorglub » : « Ce mot est déjà dans le dictionnaire. »
   Taper « 12 » : « Un mot a besoin d'au moins une lettre ». Taper « a b » : « Un seul mot ».
   « Annuler » : retour à la liste, rien ne change. Échap (dit à Dragon) annule aussi.
4. « Corriger des mots » : chaque mot a un crayon, l'explication dit « Regarde un mot pour le
   corriger ». Regarder « zorglub » : la case contient « zorglub », le curseur à la fin. En faire
   « zorglob », « Enregistrer » : retour à la liste, « Mot corrigé », « zorglob » à la place de
   « zorglub ». En tapant « zo » au clavier, « zorglob » est proposé (plus « zorglub »).
5. Corriger un mot en un mot du dictionnaire (par exemple « zorglob » → « bonjour ») : il quitte
   la liste.
6. « Retirer des mots » : les corbeilles reviennent. Regarder un mot le retire seulement après
   deux fois le délai d'activation (son anneau se remplit deux fois moins vite) ; les autres
   boutons gardent le délai habituel.
   « Retour aux paramètres » ramène à l'onglet Prédiction.
7. Le journal dit seulement « My words: ... » / « Prediction: one added word fixed », jamais les
   mots.

## 38. Un symbole devant chaque réglage (issue #165)

1. Ouvrir les paramètres et parcourir tous les onglets des quatre catégories : chaque ligne de
   réglage a un symbole gris à gauche de son nom (chronomètre pour les délais, œil, loupe,
   palette, clavier, sonnette…). Aucun symbole n'est un carré vide.
2. Les noms longs (« Volume de Windows pendant la sonnerie », en anglais "Windows volume while
   ringing") passent sur deux lignes et ne vont pas sous les boutons ; nom et explication
   restent dans la ligne.
3. Les boutons (« − », valeur, « + », interrupteurs) sont à la même place qu'avant et marchent
   comme avant.

## 39. Exporter, fusionner et remplacer le dictionnaire (issue #164)

1. Paramètres, onglet « Prédiction » : sous « Mes mots », trois petits boutons « Exporter »,
   « Fusionner », « Remplacer », et leur aide avec le dossier `Documents\Prunel\Dictionaries`.
2. Ajouter « zorglub » à Mes mots. « Exporter » : le message montre le fichier
   `FR Dictionnaire <date>.json` (EN en anglais : code de la langue de prédiction) ; il est dans le dossier (Explorateur).
3. Retirer « zorglub » de Mes mots. « Fusionner » : la liste montre le dictionnaire exporté ; le
   regarder : retour à l'onglet Prédiction, « … fusionné avec Mes mots » ; « zorglub » est de
   retour dans Mes mots.
4. Ajouter « zorglab ». « Remplacer », regarder le dictionnaire exporté : la question
   « Remplacer Mes mots … ? » avec « Oui / Non ». « Non » : rien ne change. De nouveau, « Oui » :
   « Mes mots remplacés » ; « zorglab » a disparu, « zorglub » est là. Le dossier contient
   maintenant `auto-backup.json`.
5. « Remplacer » par « Sauvegarde automatique » (symbole flèche), « Oui » : « zorglab » revient.
6. Dossier vide : la liste dit « Aucun dictionnaire exporté pour l'instant ». Un fichier abîmé
   (Bloc-notes, en effacer la moitié) : « Ce fichier est illisible : rien n'a changé ».
7. Le journal dit seulement « Prediction: dictionary merged / replaced (N added words) », jamais
   les mots.

## 40. Retour aux lettres après une lettre accentuée (issue #145)

1. Ouvrir le clavier, regarder la touche des accents « À,È,Ê » : la page des accents.
2. Regarder « é » : elle s'écrit ET la page des lettres revient toute seule.
3. Garder le regard au même endroit : la lettre maintenant sous le regard ne s'écrit PAS tant que
   le regard ne l'a pas quittée puis n'y est pas revenu.
4. De nouveau la page des accents, regarder « ou ! ou - : le caractère s'écrit et la page des
   accents RESTE.
5. Avec Maj allumée, « é » écrit « É » et la page des lettres revient.
6. Pareil avec le clavier anglais (QWERTY, page d'accents « á à â… »).

## 41. Colonne de raccourcis du menu (étape shortcuts-menu, issue #151)

1. Ouvrir plusieurs fenêtres (Bloc-notes, Explorateur, un navigateur). Ouvrir le menu : la barre
   est centrée comme avant, et un bouton « Raccourcis » (grille de carrés) apparaît seul près du
   coin en bas à droite, sans toucher la barre.
   La barre n'a plus que Paramètres, Clavier, Pause et Quitter Prunel (plus de Jeu, Appeler,
   Suivi souris).
2. Regarder « Raccourcis » : il prend un bord vert et une colonne se déplie au-dessus, de bas en
   haut : Windows + Tab, Jeu, Appeler, Suivi souris. Les boutons sortent de sous « Raccourcis »
   et montent, vite au départ et lentement à l'arrivée (environ 0,3 s), et arrivent tous
   ensemble. Ils ne rejouent pas l'animation quand on utilise « Appeler » ou « Suivi souris ». Avec le réglage « Libellés », les
   libellés sont à gauche des boutons.
3. Le bouton reste sous le regard : il ne replie PAS la colonne tant que le regard ne l'a pas
   quitté puis n'y est pas revenu. Le regarder de nouveau replie la colonne.
4. En regardant la colonne, le menu ne se ferme pas et aucun cercle ne s'affiche. Regarder hors
   de la barre et de la colonne pendant une seconde : tout le menu se ferme.
5. « Windows + Tab » : le menu se ferme et la vue des tâches montre les fenêtres ouvertes ; le
   cercle s'affiche par-dessus et un clic du regard sur une fenêtre la met au premier plan.
6. « Suivi souris » dans la colonne : le bord change et la colonne reste ouverte.
   « Appeler » sonne, le message s'affiche au-dessus de la barre, la colonne reste ouverte. « Jeu »
   passe en mode jeu ; depuis le mode jeu, la colonne montre « Quitter le jeu » (bord vert).
7. Pas de bouton « Raccourcis » : menu ouvert depuis la pause (seulement « Reprendre »), barre du
   clavier, confirmation de « Quitter ».
8. Petite et grande taille d'icônes (paramètres) : le bouton ne couvre jamais la barre, et la
   colonne tient dans l'écran.

## Installation complète (Setup.exe, accès à l'interface)

Prendre le zip `Prunel-setup-…` de la compilation automatique (page Actions de la pull request,
« Artifacts ») ou le `Prunel-x.y.z-setup.exe` d'un brouillon de release. Garder un autre moyen
de cliquer (voix, souris) pendant l'installation.

1. Double-cliquer sur `Prunel-…-setup.exe`. Windows peut dire « éditeur inconnu »
   (« Informations complémentaires », « Exécuter quand même »), puis demande « Oui » pour
   l'administrateur. L'installateur parle la langue de Windows ; cliquer sur « Installer », puis
   « Terminer » avec « Exécuter Prunel » coché : Prunel démarre et le journal dit « UI access:
   yes ».
2. `C:\Program Files\Prunel` existe, Prunel est dans le menu Démarrer et dans « Paramètres >
   Applications » de Windows. L'installateur a montré une seule page, « Créer une icône sur le
   Bureau » cochée, avec un bouton « Installer » (pas de « Suivant » en plus) : un raccourci
   Prunel est sur le Bureau et le démarre. La désinstallation retire ce raccourci. L'épinglage à
   la main (menu Démarrer, clic droit sur Prunel, « Épingler à la barre des tâches ») marche.
3. Ouvrir le menu Démarrer de Windows : le cercle du regard reste visible au-dessus, et un regard
   fixe puis un clic gauche ouvre un élément du menu.
4. Lancer le Bloc-notes en administrateur (clic droit, « Exécuter en tant qu'administrateur ») :
   un clic au regard y met le curseur de texte, et le clavier du regard y écrit.
5. Relancer l'installateur (mise à jour) : pas de question pour fermer Prunel (il est fermé),
   même résultat, réglages inchangés.
6. Le désinstaller depuis « Paramètres > Applications » : le dossier, le raccourci et le
   certificat « Prunel local signature » (`certlm.msc`, « Autorités de certification racines de
   confiance ») ont disparu ; les réglages sont toujours dans `%APPDATA%\Prunel`.
7. Visual Studio (F5) marche comme avant, avec « UI access: no » dans le journal.

## Venir de GazeBar (version 0.3.0)

Sur un ordinateur où GazeBar 0.2.0 est installé avec Setup.exe, avec « Démarrer avec Windows »
activé, un mot personnel et un profil enregistré :

1. Lancer `Prunel-…-setup.exe`. GazeBar est fermé sans question ; Prunel démarre.
2. `C:\Program Files\Prunel` existe (avec le dossier `Eyetracker` si GazeBar en avait un) ;
   `C:\Program Files\GazeBar` et le raccourci « GazeBar » du menu Démarrer ont disparu ;
   « Paramètres > Applications » ne montre que Prunel.
3. Les réglages sont les mêmes qu'avant (taille du cercle, langue…), le mot personnel est
   proposé, et le profil est dans la liste. `%APPDATA%\Prunel`, `%LOCALAPPDATA%\Prunel` et
   `Documents\Prunel` existent, ceux de `GazeBar` plus ; le journal dit « Former name: …
   renamed GazeBar -> Prunel ».
4. Redémarrer Windows : seul Prunel démarre (pas d'erreur sur un GazeBar.exe manquant).
5. Dans `certlm.msc`, « Autorités de certification racines de confiance » : « Prunel local
   signature » est là, « GazeBar local signature » a disparu.

## Avant de publier une version

Télécharger `Prunel-0.1.0-setup.exe` du brouillon de release (son seul fichier) et faire avec
lui le test « Installation complète » ci-dessus. Vérifier aussi : le regard fonctionne, le
clavier du regard propose des mots, `C:\Program Files\Prunel` ne contient aucun `Tobii.*.dll`
(sauf un dossier `Eyetracker` copié là à la main), et les premières lignes de
`%LOCALAPPDATA%\Prunel\prunel.log` disent « Prunel 0.1.0 starting » (le numéro de la version).
