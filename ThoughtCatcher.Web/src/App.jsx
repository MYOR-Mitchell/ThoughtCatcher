import styles from './App.module.css'

function App() {

  return (
    <div className={styles['content-wrapper']}>
      <main>
        <header>
          <h1>ThoughtCatcher</h1>
        </header>
        <div className={styles['new-thought']}>
          <input type="text" placeholder="Thought Title..." />
          <textarea placeholder="Thought Body..." />
          <button>Submit</button>
        </div>
        <div className={styles['thought-list']}>
          <h2>Thoughts</h2>
          <p>0</p>
          <div className={styles['thoughts']}>                      {/*Foreach thought I will need to create this section*/}
            <input type="text" placeholder="Thought Title..." />    {/*Value will equal fetched thought title*/}
            <textarea placeholder="Thought Body..." />              {/*Value will equal fetched thought body*/}
            <div className="thoughtButtons">
              <button>Save</button>
              <button>Delete</button>
            </div>
          </div>
        </div>
      </main >
    </div >
  )
}

export default App
