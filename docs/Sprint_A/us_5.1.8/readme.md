# US 5.1.8


## 1. Contexto

*As an Admin, I want to create a new patient profile, so that I can register their personal details and medical history.*

## 2. Requisitos


**US 5.1.8**

- 5.1.8.1. Admins can input patient details such as first name, last name, date of birth, contact information, and medical history.

- 5.1.8.2. A unique patient ID (Medical Record Number) is generated upon profile creation.

- 5.1.8.3. The system validates that the patient’s email and phone number are unique.

- 5.1.8.4. The profile is stored securely in the system, and access is governed by role-based permissions.

### 2.1. Dependências encontradas

 - 


## 3. Análise

*In this section, the team should report the study/analysis/comparison that was done in order to take the best design decisions for the requirement. This section should also include supporting diagrams/artifacts (such as domain model; use case diagrams, etc.),*

### 3.1. Respostas do cliente

>**Questão:** "It is specified that the admin can input some of the patient's information (name, date of birth, contact information, and medical history).

Do they also input the omitted information (gender, emergency contact and allergies/medical condition)?
Additionally, does the medical history that the admin inputs refer to the patient's medical record, or is it referring to the appointment history?"
> 
>**Resposta:** "The admin can not input medical history nor allergies. they can however input gender and emergency contact."

>**Questão:** ".."
> 
>**Resposta:** "..."

>**Questão:** ".."
> 
>**Resposta:** "..."

>**Questão:** ".."
> 
>**Resposta:** "..."





### 3.2. Diagrama de Sequência do Sistema (Nível 1 - Vista de Processos)

![Diagrama de Sequência do Sistema](IMG/system-sequence-diagram-level-1.svg)

### 3.3. Diagrama de Sequência do Sistema (Nível 2 - Vista de Processos)

![Diagrama de Sequência do Sistema](IMG/system-sequence-diagram-level-2.svg)

## 4. Design

*In this sections, the team should present the solution design that was adopted to solve the requirement. This should include, at least, a diagram of the realization of the functionality (e.g., sequence diagram), a class diagram (presenting the classes that support the functionality), the identification and rational behind the applied design patterns and the specification of the main tests used to validade the functionality.*

### 4.1. Diagrama de Sequência (Nível 3 - Vista de Processos)

![Diagrama de Sequência](IMG/sequence-diagram-level-3.svg)

### 4.2. Testes

**Teste 1:** *Verifies that it is not possible to create an instance of the Example class with null values.*

```
@Test(expected = IllegalArgumentException.class)
public void ensureNullIsNotAllowed() {
	Example instance = new Example(null, null);
}
```

## 5. Implementação

*In this section the team should present, if necessary, some evidencies that the implementation is according to the design. It should also describe and explain other important artifacts necessary to fully understand the implementation like, for instance, configuration files.*

*It is also a best practice to include a listing (with a brief summary) of the major commits regarding this requirement.*

...

## 6. Integração/Demonstração

*In this section the team should describe the efforts realized in order to integrate this functionality with the other parts/components of the system*

*It is also important to explain any scripts or instructions required to execute an demonstrate this functionality*

## 7. Observações

*This section should be used to include any content that does not fit any of the previous sections.*

*The team should present here, for instance, a critical prespective on the developed work including the analysis of alternative solutioons or related works*

*The team should include in this section statements/references regarding third party works that were used in the development this work.*