&SCENE:TMPH_Assistant
&ACTOR:Dan
&SPEAK:Dan
Arin...

&SCENE:TMPH_Court
&JUMP_TO_POSITION:1
&SPEAK:Arin
What? It's the right answer, right?

&SCENE:TMPH_Assistant
&SPEAK:Dan
...
&SET_POSE:Angry
No arin, we're getting a penalty for that one.

&SCENE:TMPH_Court
&SPEAK:Arin
Wait, really?

&SCENE:TMPH_Judge
&ACTOR:Brent_Judge
&SPEAK:Brent_Judge
Yes!

&SCENE:TMPH_Court
&ACTOR:Arin
&PLAY_EMOTION:ShockAnimation
&WAIT:0.5
&SET_POSE:Sweaty
&SPEAK:Arin
OOF.
&THINK:Arin
<color=\#0084ff>(I need to be more thoughtful and pay more attention I guess.)
&ISSUE_PENALTY
    -> END
