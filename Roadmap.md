# Game Development Roadmap - UAV Drone Warfare Game

## 1. Pre-production (Concept & Design)

### Story & Game Design Document
- Write a Game Design Document (GDD) that includes:
  - Storyline
  - Character profiles
  - Day-by-day missions
  - Decision points and branching paths
  - Endings
- Design a flowchart of player decisions and their impact on the newspaper, war progress, and personal consequences.

### Gameplay Mechanics Design
- **Core Mechanics**: Define player interaction with the UAV, missile targeting, and decision-making.
- **Decision System**: Plan how player choices affect the game world, including war and personal life.
  
### Technical Requirements
- Familiarize with Godot’s:
  - UI system
  - GDScript for logic
  - 2D engine
- Plan the use of Godot Signals for communication between game elements.

---

## 2. Prototyping

### Basic Gameplay Prototype
- Build core mechanics:
  - Player input for selecting targets.
  - Missile launch mechanics.

### Fax and Newspaper System
- Prototype the mission system:
  - Fax machine for mission delivery.
  - Dynamic newspaper UI that changes based on player actions.

### Moral Choice Mechanic
- Develop the decision-making system:
  - Use state machines or variables to track choices and their consequences.

---

## 3. Core Development

### Drone Control & Interaction
- Implement UAV control:
  - 2D map with zoom and target selection.
  - Different missile types based on mission intel.

### Mission and Decision Logic
- Develop mission logic where player actions have consequences (branching decisions).
- Track "morale" or "war progress" based on actions.

### UI and Art Design
- **Fax Machine UI**: Create a retro-futuristic interface for mission details.
- **Newspaper UI**: Design a dynamic newspaper that updates based on gameplay.
- **Map UI**: Design a map for missile targeting with simple controls.

---

## 4. Narrative Integration

### Dialogue and Text
- Write in-game text for:
  - Mission briefings via fax.
  - Newspaper headlines.
  - Personal messages (e.g., from the wife).
  
### Personal Story Arc
- Implement narrative elements leading to critical decisions (e.g., Day 15’s choice).

### Sound and Music
- Add atmospheric sounds (drones, missile launches, radio chatter).
- Incorporate minimal background music to create tension.

---

## 5. Testing and Iteration

### Gameplay Testing
- Test the decision system to ensure choices impact the story and gameplay.
- Balance the difficulty of missions and time pressures.

### Bug Fixing
- Focus on UI bugs (e.g., targeting system, newspaper display issues).
- Ensure the save/load system works to track player progress.

---

## 6. Polish and Final Details

### Refine Visuals
- Finalize low-fidelity art style (retro-futuristic aesthetics).
- Add animations for drone movement and missile targeting.

### Refine Sound Design
- Polish sound effects and music to reflect in-game events (e.g., civilian casualties, military victories).

### Optimize UI and Controls
- Ensure the interface is user-friendly, responsive, and visually appealing.

### Final Testing
- Conduct playtests to refine mechanics and ensure emotional impact from decisions.

---

## 7. Release and Post-release Support

### Beta Release
- Release a beta version for feedback on mechanics, moral choices, and narrative.

### Final Launch
- After incorporating feedback, release the game.

### Post-release Updates
- Gather player feedback on:
  - Moral decision-making.
  - Bug reports and game balance.
- Offer post-launch updates and improvements.

---

# Mission Ideas for Additional Days

# Mission Breakdown (Day 1 - Day 4)

## **Day 1: The First Strike**

### **Objective**:
- You are introduced to the game’s core mechanic: using the UAV to target one of five neighborhoods on the map of the city (similar to Gaza). You receive orders via a fax machine from the **Ministry of War**, indicating that there are suspected militant activities in one of these areas.

### **Gameplay**:
- You are instructed on how to target and send a missile to a designated neighborhood. There is little to no moral ambiguity, and the mission is straightforward.

### **Orwellian Elements**:
- **Propaganda Introduction**: Your orders refer to the mission as a necessary step for "maintaining peace and security." The briefing ends with a motivational line, such as “War is the key to lasting peace.”
- **Surveillance**: A subtle message at the top of the screen reminds you that your actions are monitored by the Ministry of War.
  
### **Outcome**:
- **Newspaper**: The next morning’s newspaper headline reports a successful strike, indicating the enemy forces were neutralized. The tone is positive and reinforces the idea of national strength.
- **Mood**: The war effort is framed as overwhelmingly positive, with no mention of civilian casualties.

## **Day 2: Targeting Leadership**

### **Objective**:
- Intelligence reports that a high-ranking militant leader is hiding in a neighborhood in the **Golan Heights**. You are ordered to eliminate the target with precision. However, intel also suggests there may be civilians in the area.

### **Gameplay**:
- The game introduces a moral choice: you can choose between a high-precision missile or a larger, more destructive bomb. The larger bomb guarantees the elimination of the target but risks higher civilian casualties.

### **Orwellian Elements**:
- **Doublethink**: The briefing implies that civilian casualties are inevitable for the greater good, encouraging the player to embrace conflicting ideas of peace and destruction simultaneously.
- **Erasure of Failure**: Regardless of your choice, the mission debrief hints that any mistake (civilian deaths) might not be mentioned in the public reports, encouraging the player to focus on mission success.

### **Outcome**:
- **Newspaper**:
  - If you use the precision strike and succeed, the newspaper praises the elimination of the militant leader.
  - If you cause civilian deaths, the newspaper mentions the militant's death but focuses on a crying woman in the background of a grainy image, subtly indicating civilian losses.
- **Mood**: The propaganda is still strong, but a small seed of doubt is introduced regarding the cost of victory.

## **Day 3: Suicide Bomber Convoy**

### **Objective**:
- Urgent intelligence reveals a suicide bombing convoy is on the move, targeting a nearby civilian outpost. You must act quickly to prevent the attack. Precision is crucial, but there is little time to confirm if civilians are nearby.

### **Gameplay**:
- The player is forced to act with little time to assess collateral damage. This adds pressure and urgency, pushing the player into a morally difficult position.

### **Orwellian Elements**:
- **Surveillance**: A voiceover or message reminds you that "Victory requires vigilance." The Ministry of War is watching your response time.
- **Conflicting Orders**: An additional fax message arrives just before the mission, suggesting that the convoy may not be as dangerous as first reported. This creates confusion but is quickly overridden by orders to strike.

### **Outcome**:
- **Newspaper**:
  - If the player acts quickly, the newspaper celebrates a victory and emphasizes the prevention of a terrorist attack.
  - If the player hesitates, the convoy reaches its destination and detonates, with the newspaper reporting the deaths of civilians and casting doubt on the player’s abilities.
- **Mood**: A somber tone begins to creep in. Civilian casualties are becoming more frequent, and the government’s portrayal of victory feels increasingly hollow.

## **Day 4: The School Bombing**

### **Objective**:
- New intel indicates that militants are using a school as a cover for their activities. Your orders are to bomb the location, but the intelligence is not verified. You must decide whether to risk bombing a civilian school.

### **Gameplay**:
- The player is given conflicting information. On the one hand, the Ministry insists that this strike is essential. On the other, there’s growing evidence that civilians, especially children, are present.

### **Orwellian Elements**:
- **Doublethink**: The orders suggest that the destruction of the school is regrettable but necessary to "secure future generations." The player is encouraged to rationalize that killing children now prevents future death.
- **War is Peace**: A message from the Ministry of War reinforces the idea that acts of destruction are crucial to maintaining peace and stability in the long term.

### **Outcome**:
- **Newspaper**:
  - If the player bombs the school, the next morning’s headline features images of dead children, but the text praises the “decisive blow against enemy infrastructure.”
  - If the player refuses, the newspaper reports a significant loss for the war effort, and militants are shown rejoicing.
- **Mood**: This is the game’s first major moral crisis. The player’s choices lead to either civilian casualties or military setbacks, pushing them into deeper moral ambiguity.

# Orwellian Concepts Introduced:

1. **Propaganda**: Day 1 introduces the idea that the government’s messaging frames every action as a step toward peace, no matter how destructive.
2. **Doublethink**: Day 2 pushes the player to hold contradictory beliefs about peace and war, especially when faced with potential civilian casualties.
3. **Surveillance**: By Day 3, the player is aware they are being constantly monitored by the Ministry of War, with the looming threat of disobedience leading to consequences.
4. **Erasure of Failure**: Throughout these days, the game shows how failures or moral mistakes are subtly ignored or reframed to fit the government’s narrative of success.


## Day 5: Aid Convoy
- **Objective**: Bomb a militant stronghold near an aid convoy.
- **Dilemma**: Risk hitting the convoy or allowing militants to escape.
- **Outcome**: The newspaper reports either a convoy hit or militant success.

## Day 6: Friendly Fire
- **Objective**: Strike a militant gathering near friendly forces.
- **Dilemma**: Risk friendly fire or allow militants to regroup.
- **Outcome**: The newspaper reports friendly casualties or enemy regrouping.

## Day 7: Civilian Uprising
- **Objective**: Quell a civilian rebellion by bombing a central square.
- **Dilemma**: Risk civilian deaths or allow the uprising to grow.
- **Outcome**: The newspaper reports crushed rebellion or civilian resistance.

## Day 8: False Flag
- **Objective**: Conflicting orders from government vs. rebel sympathizers.
- **Dilemma**: Trust the official orders or follow the rebel intel.
- **Outcome**: The newspaper reflects government propaganda or rebel success.

## Day 9: Collateral Damage
- **Objective**: Strike a fuel depot hidden in a residential area.
- **Dilemma**: Destroy enemy logistics at the cost of civilian lives.
- **Outcome**: The newspaper reports either military success or civilian destruction.

## Day 10: Hostage Situation
- **Objective**: Bomb militants using hostages as human shields.
- **Dilemma**: Sacrifice hostages to kill the militants or let them escape.
- **Outcome**: The newspaper reports dead hostages or militant victory.

## Day 11: Defector's Intel
- **Objective**: Use defector-provided intel to strike a hidden base.
- **Dilemma**: Trust the defector or risk acting on bad intel.
- **Outcome**: The newspaper reports either a major victory or bad intel failure.

## Day 12: Hospital Bombing
- **Objective**: Militants are hiding in a hospital.
- **Dilemma**: Bomb the hospital or risk letting militants use civilians as shields.
- **Outcome**: The newspaper reports either global condemnation or militant growth.

## Day 13: Spy Among Us
- **Objective**: Bomb a suspected spy’s location.
- **Dilemma**: Risk killing an innocent person or allowing leaks to the enemy.
- **Outcome**: The newspaper reflects a potential innocent death or intel leaks.

## Day 14: Media Scrutiny
- **Objective**: Journalists are near a strike zone.
- **Dilemma**: Risk bombing while journalists are present or delay the mission.
- **Outcome**: The newspaper reports either military cover-up or militant regrouping.

## Day 16: Suicide Attack
- **Objective**: Prevent a suicide bomber from reaching your base.
- **Dilemma**: Your emotional state from the previous day’s personal loss affects your judgment.
- **Outcome**: The newspaper reflects either a base saved or catastrophic loss.

## Day 17: Rebel Victory
- **Objective**: Make a final stand or evacuate as the rebels approach your base.
- **Dilemma**: Victory at a high civilian cost or surrender the city to the rebels.
- **Outcome**: The final newspaper reports either a brutal victory or rebel takeover.
