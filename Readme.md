 Corrupted Sector

António Louro (a21702439)

Hugo Martins (a21701372)

Pedro Oliveira (a21705187)



António Louro -  NPC_rotate, TextureAnimator, Trigger_RenderToggle, Animated_asset, NPC_state e Fade

Hugo Martins  - MainMenu, ChangeScene, ChangeSong, AttatchPlayer e Player

Pedro Oliveira - Animated_asset, AudioManager, CanvasManager, GivePlayerItem, Interactible, Jump_pad, Npc_state, Player, Sound, State, Teleport e Vanish_wall.

Fonte de git: https://github.com/DaPikachuOnMeth/lp2_2018_p3 (Nota: O projeto não foi desenvolvido em base de GIT mas invés através da ferramenta de Unity Collab por razões de maior controlo de merges das alterações criadas nas varias cenas)


Descrição da solução:
                                       Para este jogo foi necessário criar varias ferramentas. Estas ferramentas foram criadas com intenção de facilitar a criação de conteúdo e acelerar o processo de desenvolvimento de protótipos e experiências.

Uma grande parte dos scripts procuram a instância do player, e agem de acordo com ele estes scripts são:
                                          Jump_pad, AttatchPlayer, Npc_rotate, Teleport, ChangeScene, ChangeSong, Trigger_Disabler, Trigger_RenderToggle, Interactible e GivePlayerItem.

Existe dependências das classes entre: TextureAnimator e Animated_asset com o Npc_rotate.

A maquina de estados tem dois requerimentos um estado e uma instância de sprite. Esta instância de sprite será necessária para modificar a sprite de um gameObject com um nome especifico. Ele verifica se é necessario algum gameObject para ultrapassar para o proximo state (a não ser se tiver o bool de firstState enabled), depois remove se for necessario do inventario do jogador e passa para o proximo state. Este proximo state é especificado nas variaveis da classe, tambem necessita de ser informado qual é o numero do state dele.

Design Patterns utilizados:
                                                   Game Loop, Update.


UML:

![UML](UML.jpg)

Referências :
                            docs.unity3d.com (para varias das funções utilizadas na API do unity)