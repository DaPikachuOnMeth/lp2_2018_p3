 Corrupted Sector

Ant�nio Louro (a21702439)

Hugo Martins (a21701372)

Pedro Oliveira (a21705187)



Ant�nio Louro -  NPC_rotate, TextureAnimator, Trigger_RenderToggle, Animated_asset, NPC_state e Fade

Hugo Martins  - MainMenu, ChangeScene, ChangeSong, AttatchPlayer e Player

Pedro Oliveira - Animated_asset, AudioManager, CanvasManager, GivePlayerItem, Interactible, Jump_pad, Npc_state, Player, Sound, State, Teleport e Vanish_wall.

Fonte de git: https://github.com/DaPikachuOnMeth/lp2_2018_p3 (Nota: O projeto n�o foi desenvolvido em base de GIT mas inv�s atrav�s da ferramenta de Unity Collab por raz�es de maior controlo de merges das altera��es criadas nas varias cenas)


Descri��o da solu��o:
                                       Para este jogo foi necess�rio criar varias ferramentas. Estas ferramentas foram criadas com inten��o de facilitar a cria��o de conte�do e acelerar o processo de desenvolvimento de prot�tipos e experi�ncias.

Uma grande parte dos scripts procuram a inst�ncia do player, e agem de acordo com ele estes scripts s�o:
                                          Jump_pad, AttatchPlayer, Npc_rotate, Teleport, ChangeScene, ChangeSong, Trigger_Disabler, Trigger_RenderToggle, Interactible e GivePlayerItem.

Existe depend�ncias das classes entre: TextureAnimator e Animated_asset com o Npc_rotate.

A maquina de estados tem dois requerimentos um estado e uma inst�ncia de sprite. Esta inst�ncia de sprite ser� necess�ria para modificar a sprite de um gameObject com um nome especifico. Ele verifica se � necessario algum gameObject para ultrapassar para o proximo state (a n�o ser se tiver o bool de firstState enabled), depois remove se for necessario do inventario do jogador e passa para o proximo state. Este proximo state � especificado nas variaveis da classe, tambem necessita de ser informado qual � o numero do state dele.

Design Patterns utilizados:
                                                   Game Loop, Update.


UML:

![UML](UML.jpg)

Refer�ncias :
                            docs.unity3d.com (para varias das fun��es utilizadas na API do unity)